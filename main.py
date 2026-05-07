import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler
import gradio as gr

# Import functions from modules
from data_handler import load_and_clean_data
from model_trainer import train_rf, train_knn, evaluate

# 1. Data Preparation
file_path = 'student_exam_data.csv' # Ensure this matches your filename
df, cleaning_report = load_and_clean_data(file_path)

print("\n" + "="*45)
print("DATA PROCESSING REPORT")
print("="*45)
for line in cleaning_report:
    print(f"- {line}")
print("="*45 + "\n")

X = df[['Study Hours', 'Previous Exam Score', 'Efficiency']]
y = df['Pass/Fail']

# Stratified split to maintain class balance
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42, stratify=y)

# 2. Feature Scaling
scaler = StandardScaler()
X_train_scaled = scaler.fit_transform(X_train)
X_test_scaled = scaler.transform(X_test)

# 3. Model Training & Comparison
print("Starting Model Training with Hyper-parameter Tuning...")
rf_model = train_rf(X_train_scaled, y_train)
evaluate(rf_model, X_train_scaled, X_test_scaled, y_train, y_test, "Random Forest")

knn_model = train_knn(X_train_scaled, y_train)
evaluate(knn_model, X_train_scaled, X_test_scaled, y_train, y_test, "KNN")

# 4. User Interface (The Bonus)
def predict_ui(hours, score):
    # Apply same feature engineering as training
    efficiency = score / hours if hours > 0 else 0
    # Transform input using the trained scaler
    features = np.array([[hours, score, efficiency]])
    features_scaled = scaler.transform(features)
    # Prediction
    prediction = rf_model.predict(features_scaled)[0]
    return "Status: PASS 🎉" if prediction == 1 else "Status: FAIL ❌"

interface = gr.Interface(
    fn=predict_ui,
    inputs=[
        gr.Number(label="Study Hours"), 
        gr.Number(label="Previous Exam Score")
    ],
    outputs=gr.Textbox(label="Prediction Result"),
    title="Student Exam Success Predictor",
    description="This system uses Pattern Recognition (RF/KNN) to predict student outcomes."
)

if __name__ == "__main__":
    print("\nModels ready! Launching GUI...")
    interface.launch(share=True)