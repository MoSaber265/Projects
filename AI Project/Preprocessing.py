# Step Processing Module

import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.preprocessing import LabelEncoder

df = pd.read_csv(r'd:\courses\Artificial Intelligence\AI Project\student_exam_data_new.csv')


# First : Numpy App
print("="*30)
print("1: Numpy App =====> Array Processing")
print("="*30)

# Take data from DataFrame
dataArray= df.values
print("Array Information: ")
print(f"Data Array Shape: {dataArray.shape} " )
print(f"No. of Dimensions: {dataArray.ndim} " )
print(f"Data Type: {dataArray.dtype} " )
print(f"Dimation : {dataArray.shape[0]} Rows and {dataArray.shape[1]} Columns " )

print('*'*50)

# SubArray Selection
Student_hours= df["Study Hours"].values
Student_scores= df["Previous Exam Score"].values
Student_Result= df["Pass/Fail"].values

print(f"Student Hours Array: {Student_hours.shape} ")
print(f"Student Scores Array: {Student_scores.shape} ")
print(f"Student Result Array: {Student_Result.shape} ")
# print(f"Student Hours Array: {Student_hours} ")
# print(f"Student Scores Array: {Student_scores} ")
# print(f"Student Result Array: {Student_Result} ")

print('*'*50)


# Reshaping Array
reshaped_hours= Student_hours.reshape(-1,1)
reshaped_scores= Student_scores.reshape(-1,1)
reshaped_result= Student_Result.reshape(-1,1)
print(f"Reshaped Student Hours Array: {reshaped_hours.shape} ")
print(f"Reshaped Student Scores Array: {reshaped_scores.shape} ")
print(f"Reshaped Student Result Array: {reshaped_result.shape} ")    

print('*'*50)


#some special Array Operations
sorted_hours= np.sort(reshaped_hours)
print(f"Sorted Student Hours Array: {sorted_hours[:10]} ")

sumHousrs= np.sum(reshaped_hours)
sumScores= np.sum(reshaped_scores)
NO_Stduents=np.size(reshaped_hours)
print(f"Sum of Student Hours: {sumHousrs} ")
print(f"Sum of Student Scores: {sumScores} ")
print(f"Number of Students: {NO_Stduents} ")


# ************************************************************** 

# Second : Pandas App

print("="*30)

print("2: Pandas App =====> DataFrame Processing")
print("="*30)


# Create DataFrame from CSV

print("DataFrame Information: ")
print(f"DtaFrame Shape: {df.shape} ")
print(f"List Names: {list(df.columns)} ")

print('*'*50)

print("Data Exploration: ")
print("First 5 Rows: ")
print(df.head()) # defuat is 5   , can change it by df.head(10)
print('*'*50)
print("Last 5 Rows: ")
print(df.tail())
print('*'*50)
print("Random 5 Rows: ")    
print(df.sample(5))  
print('*'*50)

# Data Selection
print("Selecting Specific Columns: ")
print("First 5 Rows, first 2 Columns: ")
print(df.iloc[:5, :2])
print('*'*50)

print("from 10-15 Rows, all Columns: ")
print(df.iloc[10:16, :])
print('*'*50)

print("Descriptive Statistics: ")
print(df.describe())
print('*'*50)

# ********************************************************************


# Third : Matplotlib App
print("="*30)
print("3: Matplotlib App =====> Data Visualization")
print("="*30)
Student_hours= df["Study Hours"].values
Student_scores= df["Previous Exam Score"].values
Student_Result= df["Pass/Fail"].values
x_StudyHours= np.array([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])
y_Scores=Student_scores[:15]
y_Hours=Student_hours[:15]  
plt.plot(x_StudyHours, y_Scores, label='Scores', marker='+')
plt.plot(x_StudyHours, y_Hours, label='Study Hours', marker='*')
plt.title("Study Hours vs Exam Scores")
plt.xlabel("Study Hours")
plt.ylabel("Scores")
plt.legend()
plt.show()


# Scatter Plot
plt.scatter(Student_hours, Student_scores, color='green', marker='o')
plt.title("Study Hours vs Exam Scores Scatter Plot")
plt.xlabel("Study Hours")
plt.ylabel("Exam Scores")
plt.show()


# Bar Chart
pass_fail = Student_Result[:50]
passed_counts = np.sum(pass_fail == 1)
failed_counts = np.sum(pass_fail == 0)

categories=np.array(['Passed', 'Failed'])
counts = np.array([passed_counts, failed_counts])
colors = ['blue', 'orange'] 
plt.bar(categories, counts, color=colors)
plt.title("Pass/Fail Distribution")
plt.xlabel("Result")
plt.ylabel("Number of Students")   
plt.show()

colors= ["Green","Red"]
# Pie Chart
plt.pie(counts, labels=categories, colors=colors)
plt.title("Pass/Fail Distribution Pie Chart")
plt.show()

# Score Distribution Histogram
score_categories = np.array(['0-20', '20-40', '40-60', '60-80', '80-100'])
score_counts = np.array([
    np.sum((Student_scores >= 0) & (Student_scores < 20)),
    np.sum((Student_scores >= 20) & (Student_scores < 40)),
    np.sum((Student_scores >= 40) & (Student_scores < 60)),
    np.sum((Student_scores >= 60) & (Student_scores < 80)),
    np.sum((Student_scores >= 80) & (Student_scores <= 100))
])

plt.bar(score_categories, score_counts, color='purple')
plt.title("Score Distribution Histogram")
plt.xlabel("Score Ranges")
plt.ylabel("Number of Students")
plt.show()



hours_categories = np.array(['0-2', '2-4', '4-6', '6-8', '8-10'])
hours_counts = np.array([
    np.sum((Student_hours >= 0) & (Student_hours < 2)),
    np.sum((Student_hours >= 2) & (Student_hours < 4)),
    np.sum((Student_hours >= 4) & (Student_hours < 6)),
    np.sum((Student_hours >= 6) & (Student_hours < 8)),
    np.sum((Student_hours >= 8) & (Student_hours <= 10))
])

plt.bar(hours_categories, hours_counts, color='cyan')
plt.title("Study Hours Distribution Histogram")
plt.xlabel("Study Hours Ranges")
plt.ylabel("Number of Students")
plt.show()    




# ***********************************************************************
# Fourth : Sklearn App

le_study   = LabelEncoder()
le_score   = LabelEncoder()
le_final   = LabelEncoder()
print("="*30)
print("3: Sklearn App =====> Data Encodding")
print("="*30)

# print(df.head())
# #apply method for covert form num to string 
def study_hours(hours):
    if hours < 3:
        return 'Low'
    elif hours < 6:
        return 'Medium'
    elif hours < 9:
        return 'High'
    else:
        return 'Very High'

# Create Score Category
def scores(score):
    if score < 60:
        return 'Fail'
    elif score < 70:
        return 'Pass'
    elif score < 85:
        return 'Good'
    else:
        return 'Excellent'

# Create Result Text
def result_to_text(result):
    return 'Pass' if result == 1 else 'Fail'

# Add categorical columns to DataFrame
df['Study_ranking'] = df['Study Hours'].apply(study_hours)
df['Score_ranking'] = df['Previous Exam Score'].apply(scores)
df['Final Result'] = df['Pass/Fail'].apply(result_to_text)

print("*"*50)
print("DataFrame with New Categorical Columns:")
print(df[['Study Hours','Study_ranking',
          'Previous Exam Score','Score_ranking',
          'Pass/Fail','Final Result']].head(10))
print("\n" + "*"*50)



df["Study_ranking_encoded"] = le_study.fit_transform(df["Study_ranking"])
df["Score_ranking_encoded"] = le_score.fit_transform(df["Score_ranking"])
df["Final_Result_encoded"]  = le_final.fit_transform(df["Final Result"])

print("DataFrame with Encoded Columns:")
print(df[['Study_ranking','Study_ranking_encoded',
          'Score_ranking','Score_ranking_encoded',
          'Final Result','Final_Result_encoded']].head(10))
print("*"*50)



# Display all encoded columns

print(" Final DataFrame with All Encoded Columns:")
encoded_columns = [col for col in df.columns if 'encoded' in col]
print(df[encoded_columns].head(10))



# Visualization ===> boxplot of encoded columns

df.boxplot(column=['Study_ranking_encoded',
                   'Score_ranking_encoded',
                   'Final_Result_encoded'])
plt.title("Boxplot of Encoded Categorical Columns")
plt.show()