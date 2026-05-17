const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');
const path = require('path');
require('dotenv').config();

const app = express();

app.use(cors());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, 'Public')));

const authRoutes = require('./routes/authRoutes');
const courseRoutes = require('./routes/courseRoutes');
const doctorRoutes = require('./routes/doctorRoutes');
const studentRoutes = require('./routes/studentRoutes');
const advisorRoutes = require('./routes/advisorRoutes');

app.use('/api/auth', authRoutes);
app.use('/api/courses', courseRoutes);
app.use('/api/doctor', doctorRoutes);
app.use('/api/student', studentRoutes);
app.use('/api/advisor', advisorRoutes);

// كل الصفحات من Public/views
app.get('/login.html', (req, res) => {
    res.sendFile(path.join(__dirname, 'Public', 'views', 'login.html'));
});

app.get('/home.html', (req, res) => {
    res.sendFile(path.join(__dirname, 'Public', 'views', 'home.html'));
});

app.get('/courses-by-year.html', (req, res) => {
    res.sendFile(path.join(__dirname, 'Public', 'views', 'courses-by-year.html'));
});

app.get('/student-dashboard.html', (req, res) => {
    res.sendFile(path.join(__dirname, 'Public', 'views', 'student-dashboard.html'));
});

app.get('/doctor-dashboard.html', (req, res) => {
    res.sendFile(path.join(__dirname, 'Public', 'views', 'doctor-dashboard.html'));
});

app.get('/advisor-dashboard.html', (req, res) => {
    res.sendFile(path.join(__dirname, 'Public', 'views', 'advisor-dashboard.html'));
});

app.get('/admin-dashboard.html', (req, res) => {
    res.sendFile(path.join(__dirname, 'Public', 'views', 'admin-dashboard.html'));
});

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, 'Public', 'views', 'home.html'));
});

const MONGO_URI = process.env.MONGODB_URI || 'mongodb://127.0.0.1:27017/university_lms';
const PORT = process.env.PORT || 5000;

mongoose.connect(MONGO_URI)
    .then(() => {
        console.log('Database connected');
        app.listen(PORT, () => {
            console.log(`Server: http://localhost:${PORT}`);
        });
    })
    .catch(err => {
        console.error('DB Error:', err.message);
        process.exit(1);
    });

module.exports = app;