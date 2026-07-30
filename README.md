# 🚀 Nexora

<p align="center">

![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=.net)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=.net)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge)
![MediatR](https://img.shields.io/badge/MediatR-CQRS-orange?style=for-the-badge)
![JWT](https://img.shields.io/badge/JWT-Authentication-black?style=for-the-badge&logo=jsonwebtokens)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=for-the-badge&logo=swagger)

</p>

---

## 📖 About

**Nexora** is a modern project management backend built with **ASP.NET Core (.NET 10)** using **Clean Architecture** and **CQRS** principles.

The project is designed to demonstrate scalable backend architecture, secure authentication, layered application design, and modern software development practices commonly used in enterprise applications.

---

## ✨ Features

- 🔐 JWT Authentication & Authorization
- 👤 User Registration & Login
- 🔒 Secure Password Hashing with BCrypt
- ⚡ CQRS with MediatR
- 🏗️ Clean Architecture
- 🗄️ Entity Framework Core
- 🐘 PostgreSQL Integration
- 📖 Swagger / OpenAPI Documentation
- 🚨 Global Exception Handling
- 💉 Dependency Injection

---

# 🏛️ Architecture

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

# 🛠️ Tech Stack

| Category | Technology |
|----------|------------|
| Framework | ASP.NET Core (.NET 10) |
| Language | C# |
| Architecture | Clean Architecture |
| Pattern | CQRS (MediatR) |
| ORM | Entity Framework Core |
| Database | PostgreSQL |
| Authentication | JWT Bearer |
| Password Hashing | BCrypt.Net |
| API Documentation | Swagger / OpenAPI |

---

# 🚀 Getting Started

## Clone the repository

```bash
git clone https://github.com/SongulYilmaz09/Nexora.git
```

## Navigate to the project

```bash
cd Nexora
```

## Restore dependencies

```bash
dotnet restore
```

## Apply database migrations

```bash
dotnet ef database update --project src/Nexora.Persistence --startup-project src/Nexora.API
```

## Run the application

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

# 📚 Design Principles

Nexora is built around modern backend development practices, including:

- Clean Architecture
- SOLID Principles
- CQRS Pattern
- Separation of Concerns
- Dependency Injection
- Secure Authentication
- RESTful API Design
- Scalable Project Structure
- Maintainable Codebase

---

# 📂 Project Structure

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
├── .gitignore
└── Nexora.sln
```

---

# 📷 API Documentation

Interactive API documentation is available through **Swagger UI** after running the project.

```
http://localhost:5145/swagger
```

Swagger allows you to:

- Test API endpoints
- Authenticate using JWT
- Inspect request and response models
- Explore the REST API

---

# 👩‍💻 Author

**Songül Yılmaz**

Software Engineer

GitHub:  
https://github.com/SongulYilmaz09

LinkedIn:  
https://www.linkedin.com/in/songulyilmaz09/
