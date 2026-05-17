const express = require('express');
const router = express.Router();
const bcrypt = require('bcryptjs');
const User = require('../models/User');
const Student = require('../models/Student');
const Course = require('../models/Course');
const Enrollment = require('../models/Enrollment');
const Grade = require('../models/Grade');
const Attendance = require('../models/Attendance');
const Absence = require('../models/Absence');
const Doctor = require('../models/Doctor');

router.post('/login', async (req, res) => {
    try {
        let { email, password } = req.body;
        if (!email || !password) return res.status(400).json({ success: false, message: 'Email and password required' });
        email = email.trim().toLowerCase();
        const user = await User.findOne({ email });
        if (!user) return res.json({ success: false, message: 'Email not found' });
        const isMatch = await bcrypt.compare(password, user.password);
        if (!isMatch) return res.json({ success: false, message: 'Incorrect password' });
        res.json({ success: true, user: { _id: user._id, name: user.name, email: user.email, role: user.role, universityId: user.universityId } });
    } catch (error) {
        res.status(500).json({ success: false, message: 'Server error' });
    }
});

router.post('/add-user', async (req, res) => {
    try {
        const { name, email, password, universityId, role, department, level, semester } = req.body;
        if (!name || !email || !password || !role || !universityId) return res.status(400).json({ success: false, message: 'All fields required' });
        const existingUser = await User.findOne({ $or: [{ email: email.toLowerCase().trim() }, { universityId: universityId.toUpperCase().trim() }] });
        if (existingUser) return res.status(400).json({ success: false, message: 'User already exists' });
        const salt = await bcrypt.genSalt(10);
        const hashedPassword = await bcrypt.hash(password, salt);
        const newUser = await User.create({ name: name.trim(), email: email.toLowerCase().trim(), universityId: universityId.toUpperCase().trim(), role: role, password: hashedPassword });
        if (role === 'student') {
            await Student.create({ userId: newUser._id, department: department || 'CS', level: level || 1, semester: semester || 'First', gpa: 0.0, totalCredits: 0 });
            const defaultCourses = await Course.find({ code: { $in: ['CS101', 'CS102', 'MATH101', 'ENG101', 'IS101'] } });
            for (const course of defaultCourses) { await Enrollment.create({ studentId: newUser._id, courseId: course._id, semester: semester || 'First' }); }
        }
        if (role === 'doctor') { await Doctor.create({ userId: newUser._id, department: department || 'Computer Science', specialization: 'General' }); }
        res.json({ success: true, message: 'User created', userId: newUser._id });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

router.get('/search-student/:universityId', async (req, res) => {
    try {
        const user = await User.findOne({ universityId: req.params.universityId, role: 'student' });
        if (!user) return res.json({ success: false, message: 'Student not found' });
        const studentInfo = await Student.findOne({ userId: user._id });
        const enrollments = await Enrollment.find({ studentId: user._id }).populate('courseId');
        res.json({ success: true, user: user.toObject(), studentInfo: studentInfo || {}, enrollments: enrollments || [] });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

router.get('/search-student', async (req, res) => {
    try {
        const { universityId, name, email } = req.query;
        let query = { role: 'student' };
        if (universityId) query.universityId = universityId;
        if (name) query.name = { $regex: name, $options: 'i' };
        if (email) query.email = { $regex: email, $options: 'i' };
        const user = await User.findOne(query);
        if (!user) return res.json({ success: false, message: 'Student not found' });
        const studentInfo = await Student.findOne({ userId: user._id });
        res.json({ success: true, user: user.toObject(), studentInfo: studentInfo || {} });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

router.put('/update-user/:userId', async (req, res) => {
    try {
        const { name, email, universityId, role, password, department, level, semester } = req.body;
        const updatedData = { name, email, universityId, role };
        if (password) { const salt = await bcrypt.genSalt(10); updatedData.password = await bcrypt.hash(password, salt); }
        await User.findByIdAndUpdate(req.params.userId, updatedData);
        if (role === 'student') { await Student.findOneAndUpdate({ userId: req.params.userId }, { department, level, semester }, { upsert: true }); }
        res.json({ success: true, message: 'User updated' });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

router.delete('/delete-user/:userId', async (req, res) => {
    try {
        await Student.findOneAndDelete({ userId: req.params.userId });
        await Doctor.findOneAndDelete({ userId: req.params.userId });
        await Enrollment.deleteMany({ studentId: req.params.userId });
        await Grade.deleteMany({ studentId: req.params.userId });
        await Attendance.deleteMany({ studentId: req.params.userId });
        await Absence.deleteMany({ studentId: req.params.userId });
        await User.findByIdAndDelete(req.params.userId);
        res.json({ success: true, message: 'User deleted' });
    } catch (error) {
        res.status(500).json({ success: false, message: error.message });
    }
});

router.get('/students', async (req, res) => {
    try { const s = await User.find({ role: 'student' }).select('-password'); res.json({ success: true, students: s }); } 
    catch (e) { res.status(500).json({ success: false, message: e.message }); }
});

router.get('/users', async (req, res) => {
    try { const u = await User.find().select('-password'); res.json({ success: true, users: u }); } 
    catch (e) { res.status(500).json({ success: false, message: e.message }); }
});

module.exports = router;