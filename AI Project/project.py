import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.preprocessing import MinMaxScaler

# =====================================================
#  Load Data
# =====================================================
def load_data(path):
    df = pd.read_csv(path)
    print(" Data loaded successfully")
    print(f" Shape: {df.shape}")
    return df


# =====================================================
#  Initial Overview
# =====================================================
def data_overview(df):
    print("\n1. Initial Data Overview:")
    print(df.info())
    print("-"*40)


# =====================================================
#  Missing Values Analysis
# =====================================================
def missing_values_analysis(df):
    print("\n2. Missing Values Analysis:")
    print(df.isnull().sum())
    print("-"*40)


# =====================================================
#  Handle Missing Values (NULL / NOT NULL)
# =====================================================
def handle_missing_values(df):
    print("\n3. Handling Missing Values:")

    before = df.shape[0]

    df.dropna(
        subset=['Study Hours', 'Previous Exam Score', 'Pass/Fail'],
        inplace=True
    )

    after = df.shape[0]

    print(f" Rows before: {before}")
    print(f" Rows after removing NULLs: {after}")
    print(f" Removed rows: {before - after}")
    print("-"*40)


# =====================================================
#  Remove Duplicates
# =====================================================
def remove_duplicates(df):
    print("\n4. Duplicate Rows Check:")

    duplicate_count = df.duplicated().sum()
    print(f" Duplicate rows found: {duplicate_count}")

    if duplicate_count > 0:
        df.drop_duplicates(inplace=True)
        df.reset_index(drop=True, inplace=True)
        print(" Duplicates removed successfully")

    print(f" Current shape: {df.shape}")
    print("-"*40)


# =====================================================
#  Data Integrity Check
# =====================================================
def data_integrity_check(df):
    print("\n5. Data Integrity Check:")

    print("Study Hours:")
    print(f" Min: {df['Study Hours'].min()}, Max: {df['Study Hours'].max()}")

    print("\nExam Scores:")
    print(f" Min: {df['Previous Exam Score'].min()}, Max: {df['Previous Exam Score'].max()}")

    print("\nPass/Fail Values:")
    print(df['Pass/Fail'].unique())
    print("-"*40)


# =====================================================
#  Outlier Handling (IQR + Winsorization)
# =====================================================
def handle_outliers(df):
    print("\n6. Outlier Handling (Winsorization):")

    for col in ['Study Hours', 'Previous Exam Score']:
        Q1 = df[col].quantile(0.25)
        Q3 = df[col].quantile(0.75)
        IQR = Q3 - Q1

        lower = Q1 - 1.5 * IQR
        upper = Q3 + 1.5 * IQR

        df[f"{col} Cleaned"] = df[col].clip(lower, upper)

    print(" Outliers capped successfully")
    print("-"*40)


# =====================================================
#  Normalization (Min-Max Scaling)
# =====================================================
def normalize_data(df):
    print("\n7. Normalization (Min-Max Scaling):")

    scaler = MinMaxScaler()

    df[['Study Hours Normalized', 'Exam Score Normalized']] = scaler.fit_transform(
        df[['Study Hours Cleaned', 'Previous Exam Score Cleaned']]
    )

    print(" Normalization applied")
    print("-"*40)


# =====================================================
#  Box Plot Visualization
# =====================================================
def boxplot_visualization(df):
    print("\n8. Box Plot Visualization:")

    plt.figure(figsize=(10, 4))

    plt.subplot(1, 2, 1)
    plt.boxplot(df['Study Hours'])
    plt.title('Box Plot - Study Hours')

    plt.subplot(1, 2, 2)
    plt.boxplot(df['Previous Exam Score'])
    plt.title('Box Plot - Exam Score')

    plt.tight_layout()
    plt.show()


# =====================================================
#  Save Cleaned Data
# =====================================================
def save_clean_data(df, path):
    df.to_csv(path, index=False)
    print("\n Cleaned data saved successfully")
    print(f" File path: {path}")


# =====================================================
#  MAIN EXECUTION
# =====================================================
file_path = r'd:\courses\Artificial Intelligence\AI Project\student_exam_data_new.csv'
save_path = r'd:\courses\Artificial Intelligence\AI Project\new_data.csv'

df = load_data(file_path)
data_overview(df)
missing_values_analysis(df)
handle_missing_values(df)
remove_duplicates(df)
data_integrity_check(df)
handle_outliers(df)
normalize_data(df)
boxplot_visualization(df)
save_clean_data(df, save_path)

print("\n" + "="*60)
print(" DATA PREPROCESSING COMPLETED SUCCESSFULLY")
print("="*60)
