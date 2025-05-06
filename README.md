# TaskManager

TaskManager is a modern .NET 8 web API designed for efficient task and user management. It provides robust features like task assignment, role-based access control, and seamless API documentation.

---

## Table of Contents

1. [Features](#features)
2. [Technologies Used](#technologies-used)
3. [Project Structure](#project-structure)
4. [Roles and Permissions](#roles-and-permissions)
5. [Database Seed](#database-seed)
6. [Getting Started](#getting-started)
7. [Testing](#testing)
8. [Contributing](#contributing)

---

## Features

- **Task Management**: CRUD operations for tasks.
- **User Management**: Manage user data and authentication.
- **Task Assignment**: Assign tasks to specific users.
- **Authentication & Authorization**: Secure API with JWT and role-based access control.
- **Validation**: Implements FluentValidation and Data Annotations.
- **Unit Testing**: Comprehensive tests for controllers, services, and repositories.
- **Logging**: Built-in logging for errors, warnings, and information.
- **DTOs**: Simplified data transfer between API and client.
- **In-Memory Database**: For development and testing.
- **API Documentation**: Integrated Swagger for API exploration.

---

## Technologies Used

- **.NET 8**
- **FluentValidation.AspNetCore**: Model validation.
- **Microsoft.AspNetCore.Authentication.JwtBearer**: JWT-based authentication.
- **Microsoft.EntityFrameworkCore.InMemory**: In-memory database for testing.
- **Swashbuckle.AspNetCore**: Swagger API documentation.
- **xUnit**: Unit testing framework.

---

## Project Structure

The project is organized as follows:

AssessmentTaskManager
├── Controllers
│   ├── AuthController.cs
│   ├── TaskToDosController.cs
│   ├── UsersController.cs
├── Data
│   ├── TaskManagementDB.cs
│   ├── IUnitOfWork.cs
├── Models
│   ├── DtoUser.cs
│   ├── DtoUserValidator.cs
│   ├── TaskToDo.cs
│   ├── User.cs
├── Repositories
│   ├── TaskToDoRepository.cs
│   ├── UserRepository.cs
├── Services
│   ├── AuthenticationService.cs
│   ├── IdentityService.cs
│   ├── JwtService.cs
│   ├── TaskToDoService.cs
├── appsettings.json

---

## Roles and Permissions

- **Admins**:
  - Create, update, and delete all tasks.
  - List all tasks.
- **Users**:
  - Update the status of their assigned tasks.
  - Retrieve tasks assigned to them.

---

## Database Seed

The database is preloaded with:
- **Users**: 2 sample users.
- **Tasks**: 3 sample tasks.

---


## Getting Started

1. **Clone the Repository**: Clone this repository to your local machine.
2. **Install Dependencies**: Navigate to the project directory and run `dotnet restore` to install the required packages.
3. **Start the Application**: Run `dotnet run` to start the API.


