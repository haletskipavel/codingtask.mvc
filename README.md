# Task Management App (ASP.NET Core MVC with EF Core)

This is a simple Task Management application built with ASP.NET Core MVC, Entity Framework Core, and SQL Server. It demonstrates CRUD operations (Create, Read, Update, Delete) with AJAX using the Fetch API. The project also includes anti-forgery token protection to prevent CSRF attacks.

## Features

- Create, Read, Update, and Delete tasks.
- AJAX-based Create, Update, and Delete functionality.
- Anti-forgery token protection for secure operations.
- Entity Framework Core for database interactions.
- SQL Server running in a Docker container.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started) (for running SQL Server in a container)
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup) or [Azure Data Studio](https://azure.microsoft.com/en-us/services/data-studio/) for interacting with the database (optional)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/task-management-app.git
cd task-management-app
