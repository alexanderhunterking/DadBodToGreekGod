# Dad Bod to Greek God - Meal Prep App

## Overview

"Dad Bod to Greek God" is a meal preparation application designed to help users transform their eating habits and achieve a healthier lifestyle. Whether you're aiming for weight loss, muscle gain, or simply maintaining a balanced diet, this app provides the tools you need to plan, track, and enjoy your meals.

## Features

- **Meal Planning**: Schedule your meals for the week, including breakfast, lunch, dinner, and snacks.
- **Recipe Repository**: Access a diverse collection of recipes tailored to your dietary goals.
- **Ingredient Management**: Keep track of ingredients, nutritional information, and create shopping lists.
- **Calendar Integration**: Plan your meals on a weekly calendar for better organization.
- **User Meal Assignments**: Assign meals to specific times of the day for personalized routines.
- **Macro Tracking**: Monitor your macronutrient intake to meet your fitness goals.

## Technologies Used

- **Backend**: ASP.NET Core, Entity Framework, C#
- **Frontend**: Vanilla with a little bit of bootstrap
- **Database**: SQL Server or any supported database
- **Authentication**: JWT (JSON Web Tokens)
- **Dependency Injection**: .NET Core DI
- **API Documentation**: Swagger/OpenAPI

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository: `git clone https://github.com/yourusername/dad-bod-to-greek-god.git`

### Configuration

1. Configure the database connection in `appsettings.json`.
2. Run migrations: `dotnet ef database update` (make sure to have EF tools installed).

### Running the App

- Run the backend: `dotnet run` (Visit `https://localhost:5001` in your browser).
- Run the frontend: `npm run dev` (Visit `http://localhost:3000` in your browser).

## API Documentation

Explore the API endpoints using Swagger by visiting `https://localhost:5001/swagger`.
