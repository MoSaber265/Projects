import numpy as np 
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.feature_selection import SelectKBest, f_classif
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler
from sklearn.decomposition import PCA
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import accuracy_score
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
#  Handle Missing Values
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
    print(f" Min: {df['Study Hours'].min()}\n Max: {df['Study Hours'].max()}")

    print("\nExam Scores:")
    print(f" Min: {df['Previous Exam Score'].min()}\n Max: {df['Previous Exam Score'].max()}")

    print("\nPass/Fail Values:")
    print(df['Pass/Fail'].unique())
    print("-"*40)


# =====================================================
#  Outlier Handling
# =====================================================
def handle_outliers(df):
    print("before outliers")
    print(df)
    print("\n6. Outlier Handling:")

    for col in ['Study Hours', 'Previous Exam Score']:
        Q1 = df[col].quantile(0.25)
        Q3 = df[col].quantile(0.75)
        IQR = Q3 - Q1

        lower = Q1 - 1.5 * IQR
        upper = Q3 + 1.5 * IQR

        df[col] = df[col].clip(lower, upper)

    print(" Outliers handled successfully")
    print(df)
    print("-"*40)
   


# =====================================================
#  Fix Pass / Fail
# =====================================================
def fix_pass_fail_labels(df):
    print("\n7. Fixing Pass/Fail Labels:")

    df['Pass/Fail'] = (df['Previous Exam Score'] >= 50).astype(int)

    print(" Pass/Fail column corrected")
    print("-"*40)


# =====================================================
#  Feature Engineering
# =====================================================
def add_efficiency_feature(df):
    print("\n8. Feature Engineering: Efficiency")

    df['Efficiency'] = df['Previous Exam Score'] / df['Study Hours']

    # Handle division by zero
    df.replace([np.inf, -np.inf], 0, inplace=True)

    print(" Efficiency feature added successfully")
    print("-"*40)

# =====================================================
#  Feature Selection Correlation
# =====================================================
def feature_correlation(df):
    print("\n9. Feature Correlation")

    corr_matrix = df.corr()
    print("\nCorrelation Matrix:\n", corr_matrix)

    target_corr = corr_matrix['Pass/Fail'].drop('Pass/Fail')
    print("\n Correlation Target :\n", target_corr)

    important_features = target_corr.abs().sort_values(ascending=False)
    print("\nFeatures correlation:")
    print(important_features)
    print("-"*40) 
 
 # =====================================================
#  Feature Selection f_classif
# =====================================================
def feature_f_classif(df):
    print("\n10. Feature f_classif")

    X = df[['Study Hours', 'Previous Exam Score', 'Efficiency']]
    y = df['Pass/Fail']

    f_selector = SelectKBest(score_func=f_classif, k='all')
    f_selector.fit(X, y)
    f_scores = pd.Series(f_selector.scores_, index=X.columns)
    
    print("\ntest Scores:")
    print(f_scores.sort_values(ascending=False))
    print("-"*40)

# =====================================================
#  Feature Extraction: Scaling + PCA
# =====================================================
def feature_extraction(df, n_components=2):
    print("\nFEATURE EXTRACTION: Scaling + PCA")
    
    features = ['Study Hours', 'Previous Exam Score', 'Efficiency']
    
    X = df[features].values
    y = df['Pass/Fail'].values

    print(f" Original Features Shape: {X.shape}")

    scaler = StandardScaler()
    X_scaled = scaler.fit_transform(X)
    print(" Scaling applied: mean=0, std=1")

    pca = PCA(n_components=n_components)
    X_pca = pca.fit_transform(X_scaled)
    print(f" PCA applied: reduced to {n_components} components")
    print(f" Explained Variance Ratio: {pca.explained_variance_ratio_}")

    pca_columns = [f'PC{i+1}' for i in range(n_components)]
    df_pca = pd.DataFrame(X_pca, columns=pca_columns)
    df_pca['Pass/Fail'] = y

    print(" Feature Extraction completed successfully")
    print("-"*40)
    return df_pca

# =====================================================
#  Data Visualization
# =====================================================
def visualize_data(df):
    print("\n9. Data Visualization (All in one figure):")

    fig, axes = plt.subplots(2, 3, figsize=(18, 10))
    fig.suptitle('Data Visualizations', fontsize=16)

    # Histogram for Study Hours
    axes[0, 0].hist(df['Study Hours'], bins=20, color='skyblue', edgecolor='black')
    axes[0, 0].set_title('Distribution of Study Hours')
    axes[0, 0].set_xlabel('Study Hours')
    axes[0, 0].set_ylabel('Frequency')

    # Histogram for Previous Exam Score
    axes[0, 1].hist(df['Previous Exam Score'], bins=20, color='salmon', edgecolor='black')
    axes[0, 1].set_title('Distribution of Previous Exam Score')
    axes[0, 1].set_xlabel('Previous Exam Score')
    axes[0, 1].set_ylabel('Frequency')

    # Histogram for Efficiency
    axes[0, 2].hist(df['Efficiency'], bins=20, color='lightgreen', edgecolor='black')
    axes[0, 2].set_title('Distribution of Efficiency')
    axes[0, 2].set_xlabel('Efficiency')
    axes[0, 2].set_ylabel('Frequency')

    # Scatter plot Study Hours vs Previous Exam Score
    axes[1, 0].scatter(df['Study Hours'], df['Previous Exam Score'], c=df['Pass/Fail'], cmap='bwr', alpha=0.7)
    axes[1, 0].set_title('Study Hours vs Previous Exam Score')
    axes[1, 0].set_xlabel('Study Hours')
    axes[1, 0].set_ylabel('Previous Exam Score')

    # Scatter plot Study Hours vs Efficiency
    axes[1, 1].scatter(df['Study Hours'], df['Efficiency'], c=df['Pass/Fail'], cmap='bwr', alpha=0.7)
    axes[1, 1].set_title('Study Hours vs Efficiency')
    axes[1, 1].set_xlabel('Study Hours')
    axes[1, 1].set_ylabel('Efficiency')

    # Scatter plot Previous Exam Score vs Efficiency
    axes[1, 2].scatter(df['Previous Exam Score'], df['Efficiency'], c=df['Pass/Fail'], cmap='bwr', alpha=0.7)
    axes[1, 2].set_title('Previous Exam Score vs Efficiency')
    axes[1, 2].set_xlabel('Previous Exam Score')
    axes[1, 2].set_ylabel('Efficiency')

    plt.tight_layout(rect=[0, 0, 1, 0.96])
    plt.show()

    print(" Visualization completed successfully")
    print("-"*40)

# =====================================================
#  Train/Test Split
# =====================================================
def split_train_test(df, test_size=0.2, random_state=42,):
    print("\n9. Train/Test Split:")

    # Features & Target
    X = df[['Study Hours', 'Previous Exam Score', 'Efficiency']]
    y = df['Pass/Fail']

    # Split
    X_train, X_test, y_train, y_test = train_test_split(
        X, y, test_size=test_size, random_state=random_state,stratify=y
    )

    print(f" X_train shape: {X_train.shape}, y_train shape: {y_train.shape}")
    print(f" X_test shape: {X_test.shape}, y_test shape: {y_test.shape}")
    print("-"*40)

    return X_train, X_test, y_train, y_test

# =====================================================
#  Save Final Data
# =====================================================
def save_clean_data(df, path):
    df.to_csv(path, index=False)
    print("\n Feature-ready data saved successfully")
    print(f" File path: {path}")

from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import accuracy_score

# =====================================================
#  Random Forest Model
# =====================================================
def random_forest_model(X_train, X_test, y_train, y_test, n_estimators=10, random_state=42):
    print("\nTRAINING RANDOM FOREST MODEL:")

    rf = RandomForestClassifier(n_estimators=n_estimators, random_state=random_state)

    rf.fit(X_train, y_train)

    y_pred = rf.predict(X_test)

    accuracy = accuracy_score(y_test, y_pred)
    print(f"Random Forest Accuracy: {accuracy:.0%}")
    
    return rf

# =====================================================
#  MAIN EXECUTION
# =====================================================

file_path = r'd:\courses\Artificial Intelligence\AI Project\student_exam_data_new.csv'
save_path = r'd:\courses\Artificial Intelligence\AI Project\new_data.csv'
save_path_extraction = r'd:\courses\Artificial Intelligence\AI Project\new_data.csv' 
df = load_data(file_path)
# data_overview(df)
missing_values_analysis(df)
handle_missing_values(df)
remove_duplicates(df)
data_integrity_check(df)
handle_outliers(df)
fix_pass_fail_labels(df)
add_efficiency_feature(df)
feature_correlation(df)
feature_f_classif(df)
df_features = feature_extraction(df, n_components=2)
df_features.to_csv(save_path_extraction, index=False)
X_train, X_test, y_train, y_test = split_train_test(df)
rf_model = random_forest_model(X_train, X_test, y_train, y_test)
visualize_data(df)
save_clean_data(df, save_path)

print("\n" + "="*60)
print(" FEATURE ENGINEERING COMPLETED SUCCESSFULLY")
print("="*60)
