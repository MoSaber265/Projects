# =====================================================
# IMPORTS
# =====================================================
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

from sklearn.model_selection import train_test_split, cross_val_score
from sklearn.pipeline import Pipeline
from sklearn.preprocessing import StandardScaler
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import (
    accuracy_score,
    confusion_matrix,
    classification_report
)

# =====================================================
# LOAD DATA
# =====================================================
def load_data(path):
    df = pd.read_csv(path)
    print("Data loaded successfully")
    print("Shape:", df.shape)
    return df

# =====================================================
# DATA CLEANING
# =====================================================
def clean_data(df):
    df = df.dropna(subset=['Study Hours', 'Previous Exam Score', 'Pass/Fail'])
    df = df.drop_duplicates().reset_index(drop=True)
    return df

# =====================================================
# TRAIN / TEST SPLIT (NO LEAKAGE)
# =====================================================
def split_data(df):
    X = df[['Study Hours', 'Previous Exam Score']]
    y = df['Pass/Fail']

    return train_test_split(
        X, y,
        test_size=0.2,
        random_state=42,
        stratify=y
    )

# =====================================================
# FEATURE ENGINEERING (AFTER SPLIT)
# =====================================================
def add_efficiency(X):
    X = X.copy()
    X['Efficiency'] = X['Previous Exam Score'] / X['Study Hours']
    X.replace([np.inf, -np.inf], 0, inplace=True)
    return X

# =====================================================
# RANDOM FOREST MODEL (ANTI-OVERFITTING)
# =====================================================
def train_random_forest(X_train, X_test, y_train, y_test):

    X_train = add_efficiency(X_train)
    X_test = add_efficiency(X_test)

    pipeline = Pipeline([
        ('scaler', StandardScaler()),
        ('rf', RandomForestClassifier(
            n_estimators=200,
            max_depth=6,
            min_samples_leaf=5,
            random_state=42
        ))
    ])

    pipeline.fit(X_train, y_train)

    y_pred = pipeline.predict(X_test)

    print("\nAccuracy:", accuracy_score(y_test, y_pred))
    print("\nConfusion Matrix:\n", confusion_matrix(y_test, y_pred))
    print("\nClassification Report:\n", classification_report(y_test, y_pred))

    # Cross Validation
    X_full = pd.concat([X_train, X_test])
    y_full = pd.concat([y_train, y_test])

    cv_scores = cross_val_score(
        pipeline,
        X_full,
        y_full,
        cv=5
    )

    print("\nCross-Validation Scores:", cv_scores)
    print("Mean CV Accuracy:", cv_scores.mean())

    return pipeline

# =====================================================
# VISUALIZATION
# =====================================================
def visualize_data(df):
    plt.figure(figsize=(10, 5))

    plt.subplot(1, 2, 1)
    plt.scatter(df['Study Hours'], df['Previous Exam Score'],
                c=df['Pass/Fail'], cmap='bwr', alpha=0.7)
    plt.xlabel('Study Hours')
    plt.ylabel('Previous Exam Score')
    plt.title('Study Hours vs Score')

    plt.subplot(1, 2, 2)
    efficiency = df['Previous Exam Score'] / df['Study Hours']
    efficiency.replace([np.inf, -np.inf], 0, inplace=True)
    plt.hist(efficiency, bins=20)
    plt.title('Efficiency Distribution')

    plt.tight_layout()
    plt.show()

# =====================================================
# SAVE CLEAN DATA
# =====================================================
def save_clean_data(df, path):
    df.to_csv(path, index=False)
    print("Clean data saved to:", path)

# =====================================================
# MAIN
# =====================================================
file_path = r'd:\courses\Artificial Intelligence\AI Project\student_exam_data_new.csv'
save_path = r'd:\courses\Artificial Intelligence\AI Project\clean_data_final.csv'

df = load_data(file_path)
df = clean_data(df)

X_train, X_test, y_train, y_test = split_data(df)

model = train_random_forest(X_train, X_test, y_train, y_test)

visualize_data(df)
save_clean_data(df, save_path)

print("\n" + "="*60)
print("ML PIPELINE COMPLETED CORRECTLY")
print("="*60)
