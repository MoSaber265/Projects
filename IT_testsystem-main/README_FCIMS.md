<div align="center">

# 🎓 Faculty of Computing & Information Management System
### **FCIMS** — نظام إدارة كلية الحاسبات والمعلومات المتكامل

<br/>

[![Node.js](https://img.shields.io/badge/Node.js-v18+-339933?style=for-the-badge&logo=node.js&logoColor=white)](https://nodejs.org)
[![Express](https://img.shields.io/badge/Express.js-v4+-000000?style=for-the-badge&logo=express&logoColor=white)](https://expressjs.com)
[![MongoDB](https://img.shields.io/badge/MongoDB-v7+-47A248?style=for-the-badge&logo=mongodb&logoColor=white)](https://mongodb.com)
[![JavaScript](https://img.shields.io/badge/JavaScript-Vanilla-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)]()
[![bcrypt](https://img.shields.io/badge/Auth-bcrypt-red?style=for-the-badge)]()

<br/>

> نظام متكامل لإدارة الكليات يدعم **4 أدوار** مختلفة بصلاحيات منفصلة —  
> طالب · دكتور · مرشد أكاديمي · أدمن

<br/>

![separator](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

</div>

<br/>

## 📌 Table of Contents

- [Project Overview](#-project-overview)
- [User Roles](#-user-roles)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Database Models](#-database-models)
- [Database Schema (ER)](#-database-schema-er)
- [API Endpoints](#-api-endpoints)
- [Frontend Pages](#-frontend-pages)
- [Installation & Setup](#-installation--setup)
- [Test Accounts](#-test-accounts)
- [Key Features](#-key-features)
- [Future Enhancements](#-future-enhancements)

<br/>

---

## 🧠 Project Overview

**FCIMS** is a full-stack web application built to manage all academic operations within a Faculty of Computing and Information. It provides dedicated dashboards for each user role, a RESTful API backend, and a responsive Arabic-supported frontend.

```
Client (HTML/CSS/JS)  ──►  Express.js Server  ──►  MongoDB Database
                               │
                    ┌──────────┴──────────┐
                    │     REST API         │
                    │  /api/auth           │
                    │  /api/student        │
                    │  /api/doctor         │
                    │  /api/advisor        │
                    └─────────────────────┘
```

<br/>

---

## 👥 User Roles

| Role | Dashboard | Permissions |
|:-----|:----------|:------------|
| 👨‍🎓 **Student** | `student-dashboard` | View courses, grades, absences · Register/drop courses · View schedule |
| 👨‍🏫 **Doctor** | `doctor-dashboard` | Manage courses · Add grades · Record absences · Search students |
| 🎓 **Advisor** | `advisor-dashboard` | Full edit access — students, courses, grades, schedule, absences |
| 👑 **Admin** | `admin-dashboard` | Full user management — add, edit, delete all users |

<br/>

---

## 🛠️ Tech Stack

| Layer | Technology | Version |
|:------|:-----------|:-------:|
| **Backend** | Node.js + Express.js | v18+ / v4+ |
| **Database** | MongoDB + Mongoose ODM | v7+ |
| **Frontend** | HTML5 + CSS3 + JavaScript | Vanilla |
| **Authentication** | bcrypt (password hashing) | v5+ |
| **Environment** | dotenv | v16+ |
| **Dev Tool** | nodemon | v3+ |

<br/>

---

## 📁 Project Structure

```
Faculty-of-Computing-and-Information-Management-System/
│
├── 📁 models/                        # Database Models (Mongoose Schemas)
│   ├── User.js                      # Base user (all roles)
│   ├── Student.js                   # Student profile data
│   ├── Doctor.js                    # Doctor profile data
│   ├── Course.js                    # Course definitions
│   ├── Enrollment.js                # Student–Course registrations
│   ├── Grade.js                     # Grades & assessments
│   ├── Attendance.js                # Daily attendance records
│   ├── Absence.js                   # Detailed absence tracking
│   ├── Schedule.js                  # Student timetables
│   ├── Material.js                  # Recorded lectures & links
│   └── AvailableCourse.js           # Courses open for enrollment
│
├── 📁 routes/                        # Express API Routes
│   ├── authRoutes.js                # Login, user management
│   ├── studentRoutes.js             # Student-specific endpoints
│   ├── doctorRoutes.js              # Doctor-specific endpoints
│   ├── advisorRoutes.js             # Advisor-specific endpoints
│   └── courseRoutes.js              # Course management
│
├── 📁 Public/                        # Static Assets
│   ├── css/style.css               # Global styles
│   ├── js/main.js                  # Shared JS utilities
│   └── index.html                   # Landing page
│
├── 📁 views/                         # Frontend HTML Pages
│   ├── login.html                   # Login page
│   ├── register.html                # Registration page
│   ├── student-dashboard.html       # Student panel
│   ├── doctor-dashboard.html        # Doctor panel
│   ├── advisor-dashboard.html       # Advisor panel
│   ├── admin-dashboard.html         # Admin panel
│   ├── search-student.html          # Student search
│   └── index.html                   # Welcome page
│
├── 📄 server.js                      # App entry point
├── 📄 seed.js                        # Database seeder
├── 📄 .env                           # Environment variables
├── 📄 package.json                   # Dependencies & scripts
└── 📄 README.md                      # This file
```

<br/>

---

## 📦 Database Models

<details>
<summary><b>1. User.js — Base User (click to expand)</b></summary>

```javascript
{
    name:         String,   // Full name
    email:        String,   // Unique email
    password:     String,   // bcrypt hashed
    universityId: String,   // Unique university code
    role:         String    // student | doctor | advisor | admin
}
```
</details>

<details>
<summary><b>2. Student.js — Student Profile</b></summary>

```javascript
{
    userId:     ObjectId,   // ref → User
    department: String,     // CS | IS | AI | SE | CY
    level:      Number,     // 1–4
    semester:   String,     // e.g. "2024-Spring"
    gpa:        Number      // cumulative GPA
}
```
</details>

<details>
<summary><b>3. Doctor.js — Doctor Profile</b></summary>

```javascript
{
    userId:     ObjectId,   // ref → User
    department: String,     // Department
    title:      String      // Professor | Doctor | TA
}
```
</details>

<details>
<summary><b>4. Course.js — Course</b></summary>

```javascript
{
    title:    String,       // Course name
    code:     String,       // Unique course code
    doctorId: ObjectId      // ref → Doctor
}
```
</details>

<details>
<summary><b>5. Enrollment.js — Course Registration</b></summary>

```javascript
{
    studentId: ObjectId,    // ref → Student
    courseId:  ObjectId,    // ref → Course
    semester:  String
}
```
</details>

<details>
<summary><b>6. Grade.js — Grades</b></summary>

```javascript
{
    studentId:  ObjectId,   // ref → Student
    courseId:   ObjectId,   // ref → Course
    type:       String,     // Quiz | Midterm | Final
    grade:      Number,
    totalGrade: Number,
    date:       Date
}
```
</details>

<details>
<summary><b>7. Attendance.js — Attendance</b></summary>

```javascript
{
    studentId: ObjectId,    // ref → Student
    courseId:  ObjectId,    // ref → Course
    status:    String,      // Present | Absent
    date:      Date
}
```
</details>

<details>
<summary><b>8. Absence.js — Detailed Absences</b></summary>

```javascript
{
    studentId:       ObjectId,
    courseId:        ObjectId,
    lectureAbsences: Number,
    sectionAbsences: Number,
    totalAbsences:   Number,   // auto-calculated
    semester:        String
}
```
</details>

<details>
<summary><b>9. Schedule.js — Timetable</b></summary>

```javascript
{
    studentId: ObjectId,
    courseId:  ObjectId,
    day:       String,     // Sunday | Monday | ...
    time:      String,     // "09:00 - 11:00"
    room:      String
}
```
</details>

<details>
<summary><b>10. Material.js — Lecture Resources</b></summary>

```javascript
{
    courseId: ObjectId,
    title:    String,
    link:     String,      // Drive / YouTube URL
    date:     Date
}
```
</details>

<details>
<summary><b>11. AvailableCourse.js — Open Enrollment</b></summary>

```javascript
{
    courseId:      ObjectId,
    department:    String,
    level:         Number,
    semester:      String,
    capacity:      Number,
    enrolledCount: Number
}
```
</details>

<br/>

---

## 🗄️ Database Schema (ER)

```
                         ┌─────────────┐
                         │    User     │
                         └──────┬──────┘
                                │
              ┌─────────────────┼─────────────────┐
              ▼                 ▼                  ▼
        ┌──────────┐      ┌──────────┐       ┌──────────┐
        │ Student  │      │  Doctor  │       │  Admin   │
        └────┬─────┘      └────┬─────┘       └──────────┘
             │                 │ 1:M
             │                 ▼
             │           ┌──────────┐      ┌────────────┐
             │           │  Course  │─────►│  Material  │
             │           └──────────┘ 1:M  └────────────┘
             │
             │ M:N via Enrollment
             ▼
    ┌────────────────────────────────────────┐
    │  Grade · Attendance · Absence          │
    │  Schedule · AvailableCourse            │
    └────────────────────────────────────────┘
```

<br/>

---

## 🔌 API Endpoints

### 🔐 Auth Routes — `/api/auth`

| Method | Endpoint | Description | Access |
|:------:|:---------|:------------|:------:|
| `POST` | `/login` | User login | Public |
| `POST` | `/add-user` | Add new user | Admin |
| `GET` | `/students` | Get all users | Admin / Advisor |
| `GET` | `/student-schedule/:studentId` | Get student schedule | Student |
| `GET` | `/search-student/:universityId` | Search student | Advisor |
| `POST` | `/add-custom-grade` | Add grade | Doctor |
| `POST` | `/submit-attendance` | Record attendance | Doctor |
| `PUT` | `/update-user/:userId` | Update user | Admin |
| `DELETE` | `/delete-user/:userId` | Delete user | Admin |

### 👨‍🏫 Doctor Routes — `/api/doctor`

| Method | Endpoint | Description | Access |
|:------:|:---------|:------------|:------:|
| `GET` | `/:doctorId/courses` | Get doctor's courses | Doctor |
| `POST` | `/search-students` | Search students | Doctor |
| `POST` | `/add-grade` | Add grade | Doctor |
| `POST` | `/add-absence` | Record absence | Doctor |
| `GET` | `/departments` | Get departments list | Doctor |

### 👨‍🎓 Student Routes — `/api/student`

| Method | Endpoint | Description | Access |
|:------:|:---------|:------------|:------:|
| `GET` | `/:studentId/courses` | Get enrolled courses | Student |
| `GET` | `/:studentId/available-courses` | Get available courses | Student |
| `POST` | `/enroll` | Register for a course | Student |
| `DELETE` | `/drop-course` | Drop a course | Student |

### 🎓 Advisor Routes — `/api/advisor`

| Method | Endpoint | Description | Access |
|:------:|:---------|:------------|:------:|
| `GET` | `/search-student` | Search student | Advisor |
| `PUT` | `/update-student/:studentId` | Edit student data | Advisor |
| `PUT` | `/update-grade/:gradeId` | Edit grade | Advisor |
| `PUT` | `/update-absence/:absenceId` | Edit absence | Advisor |
| `PUT` | `/update-schedule/:scheduleId` | Edit schedule | Advisor |
| `POST` | `/update-enrollments` | Update student courses | Advisor |
| `DELETE` | `/delete-student/:studentId` | Delete student | Advisor |

<br/>

---

## 🖥️ Frontend Pages

| Page | Path | Role | Main Functions |
|:-----|:-----|:----:|:---------------|
| Login | `/login.html` | All | Authenticate users |
| Register | `/register.html` | All | Create new account |
| Student Dashboard | `/views/student-dashboard.html` | Student | Courses · Grades · Absence · Schedule · Enrollment |
| Doctor Dashboard | `/views/doctor-dashboard.html` | Doctor | Courses · Students · Grades · Attendance · Search |
| Advisor Dashboard | `/views/advisor-dashboard.html` | Advisor | Full student data editing |
| Admin Dashboard | `/views/admin-dashboard.html` | Admin | User management (add · edit · delete) |

<br/>

---

## 🚀 Installation & Setup

### Prerequisites

```
Node.js  v16 or higher
MongoDB  v6 or higher
```

### Steps

```bash
# 1. Clone the repository
git clone https://github.com/<your-username>/Faculty-of-Computing-and-Information-Management-System.git
cd Faculty-of-Computing-and-Information-Management-System

# 2. Install dependencies
npm install

# 3. Configure environment variables
cp .env.example .env
# Edit .env with your settings (see below)

# 4. Seed the database with test data
node seed.js

# 5. Start the server
node server.js

# 6. Open in browser
# http://localhost:5000/login.html
```

### Available Scripts

```bash
npm start        # Run server (production)
npm run dev      # Run with nodemon (auto-reload)
node seed.js     # Re-seed database
```

### `.env` Configuration

```env
# Server
PORT=5000

# Database
MONGO_URI=mongodb://127.0.0.1:27017/college_management

# Security
JWT_SECRET=fcims_secret_key_2024

# Environment
NODE_ENV=development
```

<br/>

---

## 🔑 Test Accounts

| Role | Email | Password | University ID |
|:-----|:------|:--------:|:-------------:|
| 👨‍🎓 Student | ahmed@student.com | `123456` | 2024001 |
| 👨‍🎓 Student | sara@student.com | `123456` | 2024002 |
| 👨‍🎓 Student | mohamed@student.com | `123456` | 2024003 |
| 👨‍🏫 Doctor | khaled@doctor.com | `123456` | DOC001 |
| 👨‍🏫 Doctor | noura@doctor.com | `123456` | DOC002 |
| 🎓 Advisor | advisor@test.com | `123456` | ADV001 |
| 👑 Admin | admin@test.com | `123456` | ADMIN001 |

<br/>

---

## ✅ Key Features

| # | Feature | Description |
|:-:|:--------|:------------|
| 1 | **Multi-Role System** | 4 roles with isolated permissions |
| 2 | **User Management** | Add · edit · delete users (Admin) |
| 3 | **Course Enrollment** | Students register available courses per level/department |
| 4 | **Grade Management** | Add and update grades (Quiz · Midterm · Final) |
| 5 | **Absence Tracking** | Lecture & section absences tracked separately |
| 6 | **Schedule Viewer** | Per-student timetable with day/time/room |
| 7 | **Advanced Search** | Search students by university ID or name |
| 8 | **Arabic UI Support** | Full RTL Arabic language support |
| 9 | **Responsive Design** | Works on all screen sizes |
| 10 | **REST API** | Clean RESTful endpoints for all operations |

<br/>

---

## 🏫 Supported Departments

| Department | Code |
|:-----------|:----:|
| Computer Science | `CS` |
| Information Systems | `IS` |
| Artificial Intelligence | `AI` |
| Software Engineering | `SE` |
| Cybersecurity | `CY` |

<br/>

---

## 🔮 Future Enhancements

- [ ] JWT Authentication for stateless security
- [ ] Notification system (email / push)
- [ ] PDF report export
- [ ] Swagger API documentation
- [ ] File & image upload support
- [ ] Advanced analytics dashboard
- [ ] Dark mode support
- [ ] Mobile app (React Native)
- [ ] Built-in chat system

<br/>

---

<div align="center">

![separator](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

**Faculty of Computing & Information Management System**

Built with Node.js 🟢 · Express ⚡ · MongoDB 🍃 · Vanilla JS 🌐

</div>
