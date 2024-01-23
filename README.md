# University Events Web Application

This is a web application for managing university events. The application provides APIs for creating, reading, updating, and deleting events. It is built using .NET Core WebAPI and PostgreSQL for the database.

## Tech Stack

- .NET Core 6
- PostgreSQL

## Features

- **List Events**: Retrieve a list of all university events.
- **Get Event by ID**: Retrieve details of a specific event using its ID.
- **Create Event**: Add a new event to the system.
- **Update Event**: Modify details of an existing event.
- **Delete Event**: Remove an event from the system.

## Getting Started

### Prerequisites

- .NET SDK 6
- PostgreSQL

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/university-events.git
    cd university-events
    ```

2. Configure the database connection in `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "WebApiDatabase": "your_postgresql_connection_string"
      },
      // Other configurations...
    }
    ```

3. Apply migrations to create the database:

    ```bash
    dotnet ef database update
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

5. Access the API at `http://localhost:5000/api/event`.

## API Documentation

API documentation is available using Swagger/OpenAPI. After running the application, navigate to:

- Swagger UI: `http://localhost:5000/swagger/index.html`
- OpenAPI JSON: `http://localhost:5000/swagger/v1/swagger.json`

## Seeding the Database

The application seeds the database with initial mock data on startup. You can customize this data in the `EventController` constructor.
