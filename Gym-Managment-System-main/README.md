# 🏋️ High-Performance Gym Management System (GMS)

A robust, full-stack web application designed to streamline gym operations. This project implements a complete **CRUD** (Create, Read, Update, Delete) system for managing members, memberships, and financial records using **ASP.NET Core MVC**.

---

## 🏗️ Project Architecture (MVC)
The project follows the **Model-View-Controller** design pattern for clean separation of concerns:
- **Models:** Defines data structures (Member, Membership, Payment, WorkoutPlan) and handles Database relations via **Entity Framework Core**.
- **Views:** Dynamic UI rendered using **Razor Pages** and **Bootstrap 5**.
- **Controllers:** Handles the business logic and orchestrates data flow between the UI and the Database.

---

## 🛠️ Detailed Features

### 👤 Member Administration
- Full tracking of member profiles (Name, Email, Phone, Join Date).
- Search and filter capabilities for quick member access.
- Dynamic profile pages showing specific workout plans and payment history.

### 💳 Membership & Billing
- **Subscription Levels:** Supports multiple tiers (e.g., Basic, Silver, Gold, Platinum).
- **Payment History:** Detailed logs for every payment transaction linked to specific members.
- **Status Tracking:** Automatically displays "No Plan" for members without active subscriptions.

### 📋 Fitness & Training
- **Workout Plans:** Ability to assign customized workout routines to members.
- **Member-Plan Mapping:** Handles Many-to-Many relationships between members and fitness programs.

### 🎨 User Interface (UI/UX)
- **Responsive Design:** Fully compatible with Mobile, Tablet, and Desktop.
- **Modern Styling:** Integrated with **Bootstrap Icons** and custom CSS for a premium "Dark/Light" aesthetic.
- **Data Validation:** Client-side and Server-side validation to ensure data integrity (e.g., Phone and Email formats).

---

## 📊 Database Schema (ERD)
The system utilizes a relational database with the following core tables:
- `Members`: Personal info and FK to Memberships.
- `Memberships`: Defines pricing and duration.
- `Payments`: Tracks member financial history.
- `MemberWorkoutPlans`: Junction table for fitness assignments.

---

## 💻 Technical Setup

### Prerequisites
- .NET 7.0 or 8.0 SDK
- SQL Server (LocalDB or Express)
- Visual Studio 2022

### Installation & Deployment
1. **Clone & Open:**
   ```bash
   git clone [https://github.com/ahmedsam001/Gym-Managment-System.git](https://github.com/ahmedsam001/Gym-Managment-System.git)