# Mantic API

Mantic API is a modern, RESTful web API designed for managing user accounts and authentication using basic authentication and authorization. It provides secure endpoints for handling account-related operations like registration, login, and token management.

## Features

- Basic Authentication for securing endpoints.
- Authorization support for different user roles.
- LocalDB integration for local development.
- Modular design following Clean Architecture principles (API, Application, Domain, Infrastructure layers).
- MIT License for public usage.

## Getting Started

### Prerequisites

Before running the application, ensure you have the following installed:

- .NET 9.0 SDK (or later).
- SQL Server LocalDB (used for local development).
- Visual Studio or any other compatible IDE.

### Setting Up

1. **Clone the repository**:

   ```bash
   git clone https://github.com/sana-ullah305/Mantic
   ```

2. **Install dependencies**:

   Navigate to the project folder and restore the dependencies using the following command:

   ```bash
   dotnet restore
   ```

3. **Update connection string**:

   The connection string has been updated to use LocalDB for local development. If necessary, you can change the connection string in `appsettings.json`.

   ```json
   "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DemoCRUDWithCADb;Trusted_Connection=True;TrustServerCertificate=True;"
   ```

4. **Run database migrations**:

   The project uses migrations to manage the database schema. To apply migrations, run the following command:

   ```bash
   dotnet ef database update
   ```

5. **Start the API**:

   You can now run the API by starting the application:

   ```bash
   dotnet run --project Mantic.API
   ```

   The API will be available at `https://localhost:7258/swagger/index.html` by default.

## API Endpoints

### Authentication

- `POST /api/account/register` - Registers a new user.
- `POST /api/account/login` - Authenticates a user and returns a JWT token.

### Authorization

Access to certain endpoints is restricted based on user roles. Use the returned JWT token for accessing authorized endpoints.

## Project Structure

The project follows a Clean Architecture pattern with separate layers for API, application services, domain models, and infrastructure.

- **Mantic.API**: Contains controllers and handles HTTP requests.
- **Mantic.Application**: Handles business logic and application services.
- **Mantic.Domain**: Contains domain entities and models (e.g., `RefreshToken`).
- **Mantic.Infrastructure**: Manages data access, migrations, and repository patterns.

## License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.

## Contributing

We welcome contributions to improve this project. If you'd like to contribute:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Make your changes and submit a pull request.

Thank you for helping us improve the project!
```

This is ready to be added to your repository as a `README.md` file. It provides instructions for setting up and contributing to the project, as well as details about the project's structure and licensing.