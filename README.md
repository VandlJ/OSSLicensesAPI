# README

This C# project is a RESTful API designed to manage and query compatibility data between software licenses. It utilizes ASP.NET Core framework for building web applications and Entity Framework Core for database operations.

## Overview

The API includes functionality for checking compatibility between two licenses, retrieving unique license names, and managing license compatibility records. The compatibility data is stored in a MySQL database.

## Database Setup

The MySQL database is used to store license compatibility data. The database schema includes a table named `license_compatibility` with columns for the first license (`License1`), the second license (`License2`), and the compatibility status (`Compatibility`). The database is populated using a Python script (`populate_database.py`) that reads data from a CSV file (`matrix.csv`) and inserts it into the `license_compatibility` table.

## API Endpoints

### Check Compatibility

- **POST** `/api/CompatibilityMatrix/CheckCompatibility`: 
  - This endpoint accepts input parameters representing two licenses (`Name1` and `Name2`) and returns the compatibility status between them.

- **GET** `/api/CompatibilityMatrix/CheckCompatibility`: 
  - This endpoint accepts query parameters representing two license names (`license1` and `license2`) and returns the compatibility status between them.

### Get Unique License Names

- **GET** `/api/CompatibilityMatrix/GetLicenses`: 
  - This endpoint retrieves a list of unique license names stored in the database.

### Swagger UI

The API is documented using Swagger/OpenAPI specification and can be explored interactively in a web browser by accessing the following URL: [http://localhost:5191/swagger](http://localhost:5191/swagger).

## Project Structure

- `Program.cs`: Configures the application and sets up the HTTP request pipeline.
- `InLicenses.cs`: Defines the input model for licenses.
- `LicenseCompatibility.cs`: Defines the model for license compatibility records.
- `ApplicationDbContext.cs`: Represents the database context for Entity Framework Core.
- `CompatibilityMatrixController.cs`: Implements the API endpoints for license compatibility management.
- `populate_database.py`: Python script to populate the MySQL database with license compatibility data from a CSV file.

## Usage

To use the API:
1. Set up a MySQL database and configure the connection string in `appsettings.json`.
2. Run the Python script `populate_database.py` to populate the database with license compatibility data.
3. Run the C# project to start the API.
4. Explore the API endpoints and interact with them using Swagger UI.

## Notes

- This project demonstrates how to build a RESTful API using ASP.NET Core, Entity Framework Core, and MySQL database.
- The Python script `populate_database.py` is provided as an example of how to automate the process of populating the database with data from a CSV file.
- For more information on configuring and using Swagger/OpenAPI with ASP.NET Core, refer to [Swashbuckle documentation](https://github.com/domaindrivendev/Swashbuckle.AspNetCore).
