# 📚 Library Management System

A full-stack web application for managing a library's books, categories, and authors. Built using **ASP.NET Core Web API** for the backend and **Angular** for the frontend.

---

## 🚀 Features

### 🖥 Frontend (Angular)
- Display books, categories, and authors
- Responsive navigation and layout
- Search functionality
- Reactive forms
- JWT-based authentication
- Role-based access (Admin/User)

### 🔧 Backend (ASP.NET Core Web API)
- RESTful API with CRUD operations for:
  - Books
  - Categories
  - Authors
  - Users (with Identity & JWT)
- Role management (Admin/User)
- Email confirmation support
- CORS configuration
- Swagger UI for API testing

---

## 🛠 Tech Stack

| Layer         | Technology                         |
|---------------|------------------------------------|
| Frontend      | Angular 17, RxJS, Angular Material |
| Backend       | ASP.NET Core 7 Web API             |
| Authentication| JWT, ASP.NET Identity              |
| Database      | SQL Server + Entity Framework Core |
| Styling       | Bootstrap 5 / Tailwind CSS         |
| Tools         | Swagger, Visual Studio, VS Code    |

---

## 📂 Project Structure

```bash
LibraryInterface/        # Angular Frontend
Library.API/             # ASP.NET Core Web API
Library.Core/            # Core Models and Interfaces
Library.Infrastructure/  # EF Configuration and Repositories
Library.User.Management/ # Identity & Auth Services
```

---

## 🔧 Setup Instructions

### 🖥 Backend Setup (ASP.NET Core)

1. Navigate to the API project:
   ```bash
   cd Library.API
   ```

2. Update `appsettings.json` with your SQL Server connection string.

3. Apply EF Core migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the API:
   ```bash
   dotnet run
   ```

### 🌐 Frontend Setup (Angular)

1. Navigate to the Angular app:
   ```bash
   cd LibraryInterface
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   ng serve
   ```

---

## 🔐 Authentication & Roles

- Register new users via the UI
- Confirm email using email service
- Roles:
  - **Admin**: Manage books, categories, and users
  - **User**: Browse books and categories

---

## 🌍 API Documentation

Swagger UI is available at:

```
https://localhost:{PORT}/swagger
```

---

## 📸 Screenshots

> Add screenshots of your app here.

---

## 🤝 Contributing

Contributions are welcome! Feel free to fork the repo and submit a PR.

---

## 📄 License

This project is licensed for educational and demo purposes.
