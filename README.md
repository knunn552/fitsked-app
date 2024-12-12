# Custom Workout Plan Application

## Project Overview

This project is a web application that enables users to build and customize their workout plans. The purpose of this application is to promote variability in workout plans to users can stay engaged throughout the week during their fitness routiens. Users can log in, register, and securely access their profiles. Authentication and authorization are managed through ASP.NET Identity, with plans for future integration with Microsoft Intra ID for enhanced security.

### Key Features

- **User Authentication & Authorization**: Managed by ASP.NET Identity; potential future integration with Microsoft Intra ID.
- **Plan Creation & Management**: Users can create a new workout plan or view and manage existing plans.
- **Week View Customization**: An interactive week view allows users to build and modify daily exercises.
- **CRUD Operations**: Full CRUD capabilities for workout plans, covering plan creation, editing, viewing, and deletion.
- **Dynamic Exercise Retrieval**: A .NET API provides a list of exercises based on workout types (e.g., Upper Body, Lower Body).

### Project Architecture

The application’s data model consists of three main tables: `Plans`, `UserWorkouts`, and `UserExercises`. These tables are integrated with ASP.NET Identity tables in SQL Server. SQL Server was chosen over SQLite due to its scalability, reliability, and enhanced features that support future public deployment.

## Technical Insight

- **Frontend & Components**: Built with Blazor components, enabling smooth navigation for plan creation, daily customization, and CRUD operations.
- **Database**: SQL Server is used for its robustness, scalability, and support for complex queries, essential for a public-facing application.
- **Backend & API**: A custom .NET API enables dynamic retrieval of exercises based on workout type, enhancing customization options for users.

## Build Steps

- Ensure latest version of .NET is installed.
- Ensure EF Core Nuget packages are updated. 
- Ensure SQL Server is installed.
- Install SSMS (Optional, but preffered).
- Clone this repository.
- Create your environment variables on your local machine:
  - AWS_EC2=false
  - DB_CONNECTION_STRING=Server=<your server name>;Database=fitsked;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true
  - EF_MIGRATE=false
  - API_BASE_URL=http://localhost:5279 (if for some reason this changes, go get the api url configured in the appsettings.json of the exercise-api project)
- Once SQL Server is correctly setup and Environment Variables have been created:
  - dotnet ef database update
  - If all this works, run the project in **Debug** mode.
 
- Clone repo with exercise-api: https://github.com/thecodeiackiller/exercise-api
- Create environment variables on local machine
  - ASPNETCORE_ENVIRONMENT=Development
  - API_DB_CONNECTION_STRING=Server=<your server name>;Database=exercises-api;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true
  - AWS_EC2=true
  - EF_MIGRATE=false
- dotnet ef database update
- If you able to connect to the api, you can verify with Swagger, Postman, or adding a plan in the app and seeing the list of exercises populate.



