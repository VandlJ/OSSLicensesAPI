import csv
import mysql.connector

# Cesta k souboru CSV
csv_file = 'matrix.csv'

# Inicializace prázdné matice
matrix = []

# Načtení dat ze souboru CSV a vytvoření matice
with open(csv_file, newline='') as file:
    reader = csv.reader(file)
    for row in reader:
        matrix_row = []
        for item in row:
            matrix_row.append(item)
        matrix.append(matrix_row)

# Vytisknutí matice (pro kontrolu)
for row in matrix:
    print(row)


# Připojení k databázi MySQL
db = mysql.connector.connect(
  host="sql.endora.cz",
  port="3313",
  user="ossdbjecoolnet",
  password="Admin123",
  database="licenses"
)

cursor = db.cursor()

# Vložení dat z matice do databáze

okay = 1

for i in range(1, len(matrix)):
    license1 = matrix[i][0]
    for j in range(1, len(matrix[i])):
        license2 = matrix[0][j]
        compatibility = matrix[i][j]
        if compatibility != "":
            cursor.execute("INSERT INTO license_compatibility (license1, license2, compatibility) VALUES (%s, %s, %s)", (license1, license2, compatibility))
            # print("License1: %s, License2: %s, Compatibility: %s" % (license1, license2, compatibility))
            print(okay)
            okay += 1

# Potvrzení změn a uzavření spojení
db.commit()
db.close()

