# Custom Workout Plan Application

## Project Overview

This project is a web application that enables users to build and customize their workout plans. Users can log in, register, and securely access their profiles. Authentication and authorization are managed through ASP.NET Identity, with plans for future integration with Microsoft Intra ID for enhanced security.

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
- **Unit Testing**: Testing is implemented using xUnit and bUnit, ensuring reliability and functionality across components.

## Future Enhancements

- **Microsoft Intra ID Integration**: Improved authorization for enterprise-level users.
- **Expanded API Features**: Additional API endpoints to support more dynamic exercise filtering and recommendations.
- **Advanced Analytics**: Integration of analytics to provide insights into workout trends and progress.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server
- [Postman](https://www.postman.com/) (for testing API endpoints)


