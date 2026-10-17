# Library Management API

A RESTful Library Management API built with ASP.NET Core and Entity Framework Core. It allows users to manage books and stores data in SQL Server.

## Technologies Used

- C#
- ASP.NET Core (.NET 9)
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## Features

- Retrieve all books
- Retrieve a book by ID
- Add a new book
- Update an existing book
- Delete a book
- Validate book title and author fields
- Store book data in SQL Server

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Books` | Get all books |
| GET | `/api/Books/{id}` | Get a book by ID |
| POST | `/api/Books` | Create a book |
| PUT | `/api/Books/{id}` | Update a book |
| DELETE | `/api/Books/{id}` | Delete a book |

## Run Locally

1. Install the .NET 9 SDK and SQL Server.
2. Configure the `DefaultConnection` connection string in `appsettings.json`.
3. Apply the Entity Framework Core database migrations, if required.
4. Run the project:

   ```powershell
   dotnet run --project .\WebApplication1.csproj
   ```

5. Open the Swagger UI URL printed by the application to test the endpoints.

## Example Request

Create a book using `POST /api/Books`:

```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin"
}
```

## Project Structure

- `Controllers/` — Handles HTTP requests.
- `Services/` — Contains book-related business logic.
- `Data/` or the relevant context file — Database access through Entity Framework Core.
- `Models/` or the relevant entity files — Book model and DTOs.
