import csv
import mysql.connector

# Path to the CSV file
csv_file = 'matrix.csv'

# Initialize an empty matrix
matrix = []

# Read data from the CSV file and create a matrix
with open(csv_file, newline='') as file:
    reader = csv.reader(file)
    for row in reader:
        matrix_row = []
        for item in row:
            matrix_row.append(item)
        matrix.append(matrix_row)

# Print the matrix (for verification)
for row in matrix:
    print(row)


# Connect to the MySQL database
db = mysql.connector.connect(
    host="sql.endora.cz",
    port="3313",
    user="ossdbjecoolnet",
    password="Admin123",
    database="licenses"
)

cursor = db.cursor()

# Insert data from the matrix into the database

insert_number = 1

for i in range(1, len(matrix)):
    license1 = matrix[i][0]
    for j in range(1, len(matrix[i])):
        license2 = matrix[0][j]
        compatibility = matrix[i][j]
        if compatibility != "":
            cursor.execute("INSERT INTO license_compatibility (license1, license2, compatibility) VALUES (%s, %s, %s)", (license1, license2, compatibility))
            # print("License1: %s, License2: %s, Compatibility: %s" % (license1, license2, compatibility))
            print("okay")
            insert_number += 1

# Commit the changes and close the connection
db.commit()
db.close()
