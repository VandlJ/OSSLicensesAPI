# OSSLicensesAPI

This project is a simple REST API for managing software licenses and their compatibility.

## Installation

1. First, clone this repository to your local machine.
2. Open the project in your favorite development environment.
3. Make sure you have the .NET SDK and MySQL installed on your computer.

## Configuration

1. Check the `appsettings.json` file in the project and ensure you have the correct connection to the MySQL database under the "DefaultConnection" key.
2. Create the necessary database in MySQL and make sure you have properly configured access credentials.

## Running

1. Open a terminal or command prompt in the project directory.
2. Run the application using the `dotnet run` command.
3. If everything goes well, the API should start running at `https://localhost:5001` (for development mode).

## Usage

1. Explore available endpoints using the Swagger interface available at `https://localhost:5001/swagger`.
2. The API offers endpoints for working with licenses (`/api/licenses`) and for checking compatibility between licenses (`/api/compatibilitymatrix`).

## Additional Information

This project uses ASP.NET Core and Entity Framework Core technologies for working with the web interface and MySQL database.
