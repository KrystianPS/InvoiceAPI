# Invoice Management API

## Overview
This is a WebAPI application built with .NET 8, following the principles of Clean Architecture. The API allows users to manage invoices, contractors, and products. It supports operations such as adding saved records to invoices, updating product prices, and adjusting VAT rates.

This project was created as a self-learning exercise in .NET development, showcasing the skills acquired so far.

## Features
- **Invoice Management**: Create, update, and retrieve invoices.
- **Contractor Management**: Add, update, and list contractors.
- **Product Management**: Add products, update prices, and modify VAT rates.
- **User Context Support**: Ensures secure access to API endpoints based on user roles and permissions.

## Technologies Used
- **.NET 8**
- **ASP.NET Core WebAPI**
- **Entity Framework Core** (for database management)
- **MediatR** (for CQRS pattern)
- **FluentValidation** (for request validation)
- **Identity & JWT Authentication** (for user management and security)
- **Swagger** (for API documentation)

## Project Structure (Clean Architecture)
```
📂 InvoiceManagementAPI
├── 📂 Application        # Business logic layer (Use Cases, DTOs, Services)
├── 📂 Domain             # Core domain models and entities
├── 📂 Infrastructure     # Database access, external services, authentication
├── 📂 WebAPI             # API controllers, middlewares, authentication setup
└── 📂 Tests              # Unit and integration tests
```

## Getting Started

### Prerequisites
- .NET 8 SDK installed
- SQL Server or PostgreSQL configured

### Installation & Setup
1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/invoice-management-api.git
   cd invoice-management-api
   ```
2. Install dependencies:
   ```sh
   dotnet restore
   ```
3. Set up database connection in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;"
   }
   ```
4. Apply migrations:
   ```sh
   dotnet ef database update
   ```
5. Run the application:
   ```sh
   dotnet run --project WebAPI
   ```
6. Access Swagger UI at:
   ```
   http://localhost:5000/swagger
   ```

## API Endpoints
### Authentication
- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Authenticate and receive a JWT token

### Invoices
- `POST /api/invoices` - Create an invoice
- `GET /api/invoices/{id}` - Get invoice details
- `PUT /api/invoices/{id}` - Update invoice

### Contractors
- `POST /api/contractors` - Add a new contractor
- `GET /api/contractors` - List all contractors

### Products
- `POST /api/products` - Add a new product
- `PUT /api/products/{id}` - Update product details (price, VAT rate)

## Security & Authentication
- Uses JWT-based authentication.
- Role-based authorization to protect sensitive operations.

## Contributing
1. Fork the repository.
2. Create a feature branch.
3. Commit your changes.
4. Submit a pull request.

## License
This project is licensed under the MIT License.

