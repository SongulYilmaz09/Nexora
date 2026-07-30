# 🚀 Nexora

Nexora is a modern project management backend built with **ASP.NET Core (.NET 10)** following **Clean Architecture** and **CQRS** principles.

The project is designed with scalability, maintainability, and clean code practices in mind. It demonstrates modern backend development concepts such as layered architecture, authentication, dependency injection, and domain separation.

---

## ✨ Features

- 🔐 JWT Authentication & Authorization
- 👤 User Registration & Login
- 🛡️ Password Hashing with BCrypt
- ⚡ CQRS using MediatR
- 🏗️ Clean Architecture
- 🗄️ Entity Framework Core
- 🐘 PostgreSQL
- 📖 Swagger / OpenAPI Documentation
- 🚨 Global Exception Handling
- 🔄 Dependency Injection

---

## 🏛️ Project Structure

```text
src
├── Nexora.API
├── Nexora.Application
├── Nexora.Domain
├── Nexora.Infrastructure
└── Nexora.Persistence
```

---

## 🛠️ Technologies

- ASP.NET Core (.NET 10)
- C#
- Entity Framework Core
- PostgreSQL
- MediatR
- JWT Bearer Authentication
- BCrypt.Net
- Swagger / OpenAPI

---

## 🚀 Getting Started

### Clone the repository

```bash
git clone https://github.com/SongulYilmaz09/Nexora.git
```

### Navigate to the project

```bash
cd Nexora
```

### Restore dependencies

```bash
dotnet restore
```

### Apply migrations

```bash
dotnet ef database update --project src/Nexora.Persistence --startup-project src/Nexora.API
```

### Run the application

```bash
dotnet run --project src/Nexora.API
```

The API will be available at:

```
http://localhost:5145
```

Swagger UI:

```
http://localhost:5145/swagger
```

---

## 🎯 Goals

Nexora aims to demonstrate modern backend development practices by focusing on:

- Clean Architecture
- SOLID Principles
- CQRS Pattern
- Secure Authentication
- Scalable Project Structure
- Maintainable Codebase
- RESTful API Design

---

## 👩‍💻 Author

**Songül Yılmaz**

Software Engineering Student

GitHub:  
https://github.com/SongulYilmaz09
