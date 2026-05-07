import pandas as pd
import numpy as np

def load_and_clean_data(path):
    df = pd.read_csv(path)
    report = []
    
    # 1. Initial State
    initial_shape = df.shape
    report.append(f"Initial Data Shape: {initial_shape[0]} rows and {initial_shape[1]} columns.")
    
    # 2. Handle Missing Values
    null_count = df[['Study Hours', 'Previous Exam Score', 'Pass/Fail']].isnull().sum().sum()
    df.dropna(subset=['Study Hours', 'Previous Exam Score', 'Pass/Fail'], inplace=True)
    report.append(f"Cleaning: Removed {null_count} rows containing missing values.")
    
    # 3. Handle Duplicates
    dup_count = df.duplicated().sum()
    df.drop_duplicates(inplace=True)
    report.append(f"Cleaning: Removed {dup_count} duplicate rows.")
    
    # 4. Handle Outliers (Capping)
    for col in ['Study Hours', 'Previous Exam Score']:
        Q1 = df[col].quantile(0.25)
        Q3 = df[col].quantile(0.75)
        IQR = Q3 - Q1
        lower = Q1 - 1.5 * IQR
        upper = Q3 + 1.5 * IQR
        outlier_count = ((df[col] < lower) | (df[col] > upper)).sum()
        df[col] = df[col].clip(lower, upper)
        report.append(f"Outliers: Capped {outlier_count} values in '{col}' using IQR method.")
    
    # 5. Feature Engineering
    df['Efficiency'] = df['Previous Exam Score'] / df['Study Hours']
    df.replace([np.inf, -np.inf], 0, inplace=True)
    report.append("Feature Engineering: Added 'Efficiency' column (Score/Hours).")
    
    # 6. Export Cleaned Data to Excel
    cleaned_file_name = 'cleaned_student_data.xlsx'
    df.to_excel(cleaned_file_name, index=False)
    
    final_shape = df.shape
    report.append(f"Final Data Shape: {final_shape[0]} rows and {final_shape[1]} columns.")
    report.append(f"Export: Cleaned data saved to '{cleaned_file_name}'.")
    
    return df, report