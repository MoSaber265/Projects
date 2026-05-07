<div align="center">

# 🎓 Student Exam Performance Predictor

### A Machine Learning Classification Project for Pattern Recognition Course

[![Python](https://img.shields.io/badge/Python-3.8+-3776AB?style=for-the-badge&logo=python&logoColor=white)](https://python.org)
[![Scikit-Learn](https://img.shields.io/badge/Scikit--Learn-1.x-F7931E?style=for-the-badge&logo=scikit-learn&logoColor=white)](https://scikit-learn.org)
[![Gradio](https://img.shields.io/badge/Gradio-UI-FF7C00?style=for-the-badge&logo=gradio&logoColor=white)](https://gradio.app)
[![Accuracy](https://img.shields.io/badge/Accuracy-100%25-brightgreen?style=for-the-badge)]()
[![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)]()

<br/>

> **Predicting whether a student will Pass or Fail** using Random Forest & KNN classifiers,  
> complete with hyperparameter tuning, cross-validation, and an interactive Gradio UI.

<br/>

![separator](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

</div>

<br/>

## 📌 Table of Contents

- [About the Project](#-about-the-project)
- [Results at a Glance](#-results-at-a-glance)
- [Project Structure](#-project-structure)
- [Dataset](#-dataset)
- [Methodology](#-methodology)
- [Models & Hyperparameter Tuning](#-models--hyperparameter-tuning)
- [Evaluation](#-evaluation)
- [Interactive UI](#-interactive-ui)
- [Installation & Usage](#-installation--usage)
- [Course Info](#-course-info)

<br/>

---

## 🧠 About the Project

This project is the **practical evaluation** for the Pattern Recognition course. The goal is to build a full end-to-end machine learning pipeline that:

1. **Loads & cleans** a real student academic dataset
2. **Engineers features** to improve model performance
3. **Trains & tunes** two classification algorithms (RF & KNN)
4. **Evaluates** models rigorously with cross-validation and test metrics
5. **Deploys** a user-friendly web interface for real-time predictions

Both classifiers achieved **100% test accuracy** and **>99% cross-validation accuracy**, demonstrating the strength of proper preprocessing and hyperparameter optimization.

<br/>

---

## 🏆 Results at a Glance

| Model | CV Accuracy | Test Accuracy | Precision | Recall | F1-Score |
|:------|:-----------:|:-------------:|:---------:|:------:|:--------:|
| 🌲 Random Forest *(tuned)* | **99.50%** | **100%** | 1.00 | 1.00 | 1.00 |
| 🔵 KNN *(tuned)* | **99.75%** | **100%** | 1.00 | 1.00 | 1.00 |

> Both models produced **perfect confusion matrices** on the test set:  
> ✅ 63 True Negatives · ✅ 37 True Positives · ❌ 0 False Positives · ❌ 0 False Negatives

<br/>

---

## 📁 Project Structure

```
student-exam-predictor/
│
├── 📄 main.py                        # Entry point — runs full pipeline + launches UI
├── 📄 data_handler.py                # Data loading, cleaning & feature engineering
├── 📄 model_trainer.py               # Model training, tuning & evaluation
│
├── 📊 student_exam_data.csv          # Raw dataset (input)
├── 📊 cleaned_student_data.xlsx      # Cleaned dataset (auto-generated output)
│
├── 📝 README.md                      # You are here
└── 📄 Mini_Paper_IEEE.docx           # IEEE-format project report
```

<br/>

---

## 📊 Dataset

| Property | Value |
|:---------|:------|
| **Source** | AI Course Academic Dataset |
| **Total Records** | 500 rows |
| **Original Features** | 3 |
| **Final Features** | 4 (after engineering) |
| **Target** | `Pass/Fail` (binary: 1 = Pass, 0 = Fail) |
| **Class Distribution** | 63% Fail · 37% Pass *(in test set)* |

### Features

| Feature | Type | Description |
|:--------|:----:|:------------|
| `Study Hours` | Numerical | Total hours studied before the exam |
| `Previous Exam Score` | Numerical | Score achieved in a prior exam |
| `Pass/Fail` | Binary (Target) | 1 = Pass, 0 = Fail |
| `Efficiency` *(engineered)* | Numerical | `Previous Exam Score / Study Hours` |

<br/>

---

## ⚙️ Methodology

### 1. 🧹 Data Preprocessing & Cleaning

The raw dataset went through a full cleaning pipeline:

- **Missing Values** → Rows with nulls in critical columns dropped
- **Duplicate Rows** → Identified and removed
- **Outliers** → Capped using the **IQR method** (1.5× IQR threshold) to preserve data volume
- **Export** → Cleaned data saved automatically to `cleaned_student_data.xlsx`

```
Initial Shape : 500 rows × 3 columns
Final Shape   : 500 rows × 4 columns
Missing Rows  : 0 removed
Duplicates    : 0 removed
Outliers      : Capped in Study Hours & Previous Exam Score
```

### 2. 🔧 Feature Engineering

A new feature **`Efficiency`** was derived:

```python
df['Efficiency'] = df['Previous Exam Score'] / df['Study Hours']
# Handles division by zero → replaced with 0
```

This captures how effectively a student performs relative to their study effort.

### 3. ⚖️ Feature Scaling

All features were normalized using **StandardScaler** (zero mean, unit variance):

```python
scaler = StandardScaler()
X_train_scaled = scaler.fit_transform(X_train)
X_test_scaled  = scaler.transform(X_test)
```

> Scaling is applied to **train only** first, then transform is applied to test — preventing data leakage.

### 4. 🔀 Train / Test Split

```python
X_train, X_test, y_train, y_test = train_test_split(
    X, y, test_size=0.2, random_state=42, stratify=y
)
# 80% Training (400 samples) | 20% Test (100 samples)
# Stratified to preserve class balance
```

<br/>

---

## 🤖 Models & Hyperparameter Tuning

Both models were tuned using **5-Fold Cross-Validated GridSearchCV**.

### 🌲 Random Forest

```python
param_grid = {
    'n_estimators' : [50, 100, 200],
    'max_depth'    : [None, 10, 20],
    'criterion'    : ['gini', 'entropy']
}
# ✅ Best: n_estimators=100, max_depth=None, criterion='gini'
```

### 🔵 K-Nearest Neighbors

```python
param_grid = {
    'n_neighbors' : [3, 5, 7, 9],
    'weights'     : ['uniform', 'distance'],
    'metric'      : ['euclidean', 'manhattan']
}
# ✅ Best: n_neighbors=5, weights='distance', metric='euclidean'
```

<br/>

---

## 📈 Evaluation

### Confusion Matrices

Both models achieved **perfect classification** on the 100-sample test set:

```
Random Forest                    KNN
─────────────────                ─────────────────
Pred: 0    Pred: 1              Pred: 0    Pred: 1
True 0: [ 63 ]  [  0 ]         True 0: [ 63 ]  [  0 ]
True 1: [  0 ]  [ 37 ]         True 1: [  0 ]  [ 37 ]
─────────────────                ─────────────────
```

### Classification Report (Both Models)

```
              precision    recall  f1-score   support

           0       1.00      1.00      1.00        63
           1       1.00      1.00      1.00        37

    accuracy                           1.00       100
   macro avg       1.00      1.00      1.00       100
weighted avg       1.00      1.00      1.00       100
```

### Cross-Validation

```
Random Forest CV Accuracy : 99.50%
KNN           CV Accuracy : 99.75%
```

> ✅ High CV accuracy confirms models are **not overfitting** and generalize well.

<br/>

---

## 🖥️ Interactive UI

A **Gradio web interface** was built as the bonus component of the project.

```python
interface = gr.Interface(
    fn=predict_ui,
    inputs=[
        gr.Number(label="Study Hours"),
        gr.Number(label="Previous Exam Score")
    ],
    outputs=gr.Textbox(label="Prediction Result"),
    title="Student Exam Success Predictor"
)
interface.launch(share=True)
```

**How it works:**
1. Enter **Study Hours** and **Previous Exam Score**
2. The system computes `Efficiency` automatically
3. Input is scaled using the **same StandardScaler** fitted on training data
4. The **Random Forest** model returns an instant prediction

```
Output examples:
  → Status: PASS 🎉
  → Status: FAIL ❌
```

<br/>

---

## 🚀 Installation & Usage

### Prerequisites

```bash
pip install pandas numpy scikit-learn matplotlib seaborn openpyxl gradio
```

### Run the Project

```bash
# 1. Clone the repository
git clone https://github.com/<your-username>/student-exam-predictor.git
cd student-exam-predictor

# 2. Add your dataset
# Place student_exam_data.csv in the project root

# 3. Run the full pipeline
python main.py
```

The script will:
- ✅ Clean and process the data
- ✅ Train both models with GridSearchCV
- ✅ Print evaluation metrics and show confusion matrices
- ✅ Launch the Gradio UI at `http://localhost:7860`

<br/>

---

## 📚 Course Info

| Field | Details |
|:------|:--------|
| **Course** | Pattern Recognition |
| **Student** | Mohamed Saber Taj El-Din |
| **Supervisor** | Eng. Mohamed Hamdy |
| **Project** | Student Exam Performance Prediction |
| **Submission** | Practical Evaluation Project |

<br/>

---

<div align="center">

![separator](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

Made with ❤️ by **Mohamed Saber Taj El-Din**

*Pattern Recognition Course — Practical Project*

</div>
