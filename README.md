![CI](https://github.com/RajeshManicavasagam/enterprise-banking-api/actions/workflows/ci.yml/badge.svg)


# Enterprise Banking Microservices (.NET 8)

This repository demonstrates a **senior-level backend architecture** using **.NET 8**,  
Clean Architecture, and microservices principles.

The project models a simplified banking system with authentication, accounts, and transactions,
focusing on **correct domain modeling, testability, and CI discipline**.

---

## 🧱 Architecture Overview

The system is composed of **independent microservices**, each owning its domain:

Identity Service → Authentication & JWT
Account Service → Account lifecycle & balance
Transaction Service → Money movement & idempotency



Each service:
- Is independently buildable
- Has its own solution file
- Follows Clean Architecture
- Can evolve independently

---

## 🛠️ Technology Stack

- **.NET 8 (LTS)**
- ASP.NET Core Web API
- Clean Architecture
- xUnit + Moq + FluentAssertions
- GitHub Actions (CI)
- In-memory persistence (replaceable with EF Core)

---

## 🔐 Identity Service

**Responsibilities**
- User authentication
- JWT token generation
- Authorization boundary for other services

**Key Concepts**
- Clean separation of Domain / Application / Infrastructure
- Stateless JWT authentication
- Unit-tested login use case

📁 `services/identity-service`

---

## 🏦 Account Service

**Responsibilities**
- Account creation
- Account state management
- Domain invariants enforcement

**Key Concepts**
- Rich domain model (no anemic entities)
- Business rules enforced inside domain
- No cross-service coupling

📁 `services/account-service`

---

## 💸 Transaction Service

**Responsibilities**
- Money transfer intent
- Idempotent transaction handling
- Transaction lifecycle management

**Key Concepts**
- Idempotency keys
- Explicit transaction states
- Safe retry handling

📁 `services/transaction-service`

---

## 🔁 CI / CD

The repository uses **GitHub Actions** to:

- Build each service independently
- Run unit tests where applicable
- Enforce consistency across services

CI is defined in: .github/workflows/ci.yml

## ▶️ Running Services Locally

Each service can be run independently:

```bash
dotnet run --project services/identity-service/Identity.API
dotnet run --project services/account-service/Account.API
dotnet run --project services/transaction-service/Transaction.API

Swagger UI is enabled for all services.

🧪 Testing

Unit tests focus on application-level business logic, not framework concerns.

dotnet test services/identity-service/IdentityService.sln




