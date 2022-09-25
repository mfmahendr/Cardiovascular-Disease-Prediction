# Cardiovascular-Disease-Prediction

Aplikasi Windows Form berbasis ML untuk memprediksi apakah seseorang memiliiki penyakit Cardiovascular atau tidak. Aplikasi ini memanfaatkan ML Model API yang telah dibuat dengan menggunakan layanan Azure Machine Learning (AutoML).

Untuk menggunakan, masukkan terlebih dahulu endpoint/uri dan api key dari model machine learning yang sudah dibangun.

## Informasi Dataset
Dataset: https://www.kaggle.com/datasets/sulianova/cardiovascular-disease-dataset

Dataset ini berisi data-data pasien yang diperiksa dan dites apakah pasien tersebut memiliki penyakit kardiovaskular atau tidak. Dataset ini terdiri dari 70.000 data pasien dengan 11 fitur dan sebuah fitur target.

Terdapat tiga tipe fitur masukan dalam dataset ini:
1.	objective, yakni fitur berisi informasi yang bersifat faktual; 
2.	examination, yakni fitur yang merupakan hasil dari medical examination; dan
3.	subjective, yakni informasi yang diberikan oleh seorang pasien.

Adapun fitur-fitur yang terdapat dalam dataset ini, yakni sebagai berikut.
* Age | Objective Feature | age | int (days)
* Height | Objective Feature | height | int (cm) |
* Weight | Objective Feature | weight | float (kg) |
* Gender | Objective Feature | gender | categorical code |
* Systolic blood pressure | Examination Feature | ap_hi | int |
* Diastolic blood pressure | Examination Feature | ap_lo | int |
* Cholesterol | Examination Feature | cholesterol | 1: normal, 2: above normal, 3: well above normal |
* Glucose | Examination Feature | gluc | 1: normal, 2: above normal, 3: well above normal |
* Smoking | Subjective Feature | smoke | binary |
* Alcohol intake | Subjective Feature | alco | binary |
* Physical activity | Subjective Feature | active | binary |
* Presence or absence of cardiovascular disease | Target Variable | cardio | binary |
