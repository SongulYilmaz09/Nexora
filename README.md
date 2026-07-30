# 🚀 Nexora

A modern project management backend built with **ASP.NET Core (.NET 10)**, following **Clean Architecture** and **CQRS** principles.

Nexora is designed as a scalable, maintainable, and secure backend application. The project demonstrates modern software architecture practices, layered design, authentication, and clean code principles commonly used in enterprise applications.

---

## ✨ Features

- 🔐 JWT Authentication & Authorization
- 👤 User Registration & Login
- 🔒 Secure Password Hashing with BCrypt
- ⚡ CQRS using MediatR
- 🏗️ Clean Architecture
- 🗄️ Entity Framework Core
- 🐘 PostgreSQL Integration
- 📖 Swagger / OpenAPI Documentation
- 🚨 Global Exception Handling
- 💉 Dependency Injection

---

## 🏛️ Architecture

```
src
├── Nexora.API
├── Nexora.Application
├── Nexora.Domain
├── Nexora.Infrastructure
└── Nexora.Persistence
```

The solution follows the principles of **Clean Architecture**, keeping business logic independent from infrastructure and presentation layers.

---

## 🛠️ Tech Stack

| Category | Technology |
|----------|------------|
| Framework | ASP.NET Core (.NET 10) |
| Language | C# |
| Architecture | Clean Architecture |
| Pattern | CQRS (MediatR) |
| ORM | Entity Framework Core |
| Database | PostgreSQL |
| Authentication | JWT Bearer |
| Password Security | BCrypt |
| API Documentation | Swagger / OpenAPI |

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

### Restore packages

```bash
dotnet restore
```

### Apply database migrations

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

## 📚 Design Principles

Nexora is built around modern backend development practices, including:

- Clean Architecture
- SOLID Principles
- Separation of Concerns
- Dependency Injection
- CQRS Pattern
- Secure Authentication
- RESTful API Design
- Scalable Project Structure

---

## 📁 Project Structure

```
Nexora
│
├── src
│   ├── Nexora.API
│   ├── Nexora.Application
│   ├── Nexora.Domain
│   ├── Nexora.Infrastructure
│   └── Nexora.Persistence
│
└── Nexora.sln
```

---

## 👩‍💻 Author

**Songül Yılmaz**

GitHub:  
https://github.com/SongulYilmaz09
