# 🎓 Student Exam Success Predictor (Pattern Recognition Project)

![Python](https://img.shields.io/badge/Python-3.8+-blue.svg)
![Machine Learning](https://img.shields.io/badge/ML-Scikit--learn-orange.svg)
![GUI](https://img.shields.io/badge/UI-Gradio-red.svg)

An advanced Pattern Recognition system that predicts student success based on study habits and previous academic performance. This project implements multiple classification models with automated hyper-parameter tuning and data cleaning pipelines.

---

## 🚀 Key Features
- **Automated Data Cleaning:** Handles missing values, duplicates, and outliers (IQR method).
- **Feature Engineering:** Introduces 'Efficiency' metric for better pattern recognition.
- **Model Comparison:** Evaluates **Random Forest** and **K-Nearest Neighbors (KNN)**.
- **Hyper-parameter Tuning:** Uses `GridSearchCV` to find the best model configurations.
- **Interactive GUI:** Built with **Gradio** for real-time inference.
- **Modular Architecture:** Clean code separated into Data, Model, and UI modules.

---

## 🛠️ Project Structure
```bash
├── data_handler.py    # Data loading, cleaning & Excel export
├── model_trainer.py   # Model training, tuning & evaluation
├── main.py            # Main entry point & Gradio UI
├── student_exam_data.csv    # Raw dataset
└── cleaned_student_data.xlsx # Auto-generated cleaned data