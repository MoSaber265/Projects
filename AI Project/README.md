# 📊 Student Exam Data Preprocessing Pipeline

### 🤖 Overview
This project implements a comprehensive **Data Preprocessing Pipeline** using Python. It transforms raw student performance data into a clean, normalized format ready for Machine Learning models. The pipeline focuses on data integrity, outlier handling, and feature scaling.

---

## 🛠️ Data Processing Steps
The script follows a professional Data Science workflow:

1. **Exploratory Data Analysis (EDA):** Initial overview of data types, shapes, and null counts.
2. **Missing Values Management:** Systematic removal of incomplete records to maintain data quality.
3. **Duplicate Handling:** Ensuring each record is unique to prevent model bias.
4. **Outlier Detection & Capping:** Using the **IQR (Interquartile Range)** method and **Winsorization** to handle extreme values in Study Hours and Exam Scores.
5. **Feature Scaling:** Applying **Min-Max Normalization** to bring all features into a consistent range (0 to 1).
6. **Visualization:** Generating Box Plots to analyze data distribution before and after cleaning.

---

## 📚 Tech Stack
- **Pandas:** For data manipulation and structural analysis.
- **NumPy:** For mathematical operations.
- **Scikit-Learn:** Specifically `MinMaxScaler` for data normalization.
- **Matplotlib:** For statistical data visualization (Box Plots).

---

## 📈 Visualizing the Impact
The pipeline includes a visualization step that helps identify:
- Distribution of Study Hours.
- Variability in Previous Exam Scores.
- Presence of Outliers through Box Plot analysis.

---

## 📂 Project Files
- **Preprocessing Script:** The main Python logic for the pipeline.
- **Input Data:** `student_exam_data_new.csv` (Raw data).
- **Output Data:** `new_data.csv` (Cleaned & Normalized data).

---
*Developed as part of my Artificial Intelligence and Machine Learning learning path.*