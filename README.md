# Enterprise Banking API

Microservices-oriented backend system demonstrating enterprise-grade
architecture, security, and engineering practices using **.NET / C#**.

This project is designed as a **realistic backend system**, similar to what is
built and maintained in banking or regulated enterprise environments.

---

## Overview

The Enterprise Banking API is a backend system composed of multiple
independently deployable services, each responsible for a clearly defined
business capability.

The project focuses on:
- Clean and maintainable architecture
- Clear service boundaries
- Secure REST API design
- CI/CD automation
- Pragmatic microservices (not over-engineered)

---

## Architecture

The system follows a **microservices-oriented architecture** with the following
principles:

- Each service owns its **business logic and data**
- Services communicate via **RESTful APIs**
- Clean Architecture is applied within each service
- Infrastructure concerns are isolated from business logic

High-level structure:

Client
|
|-- Identity Service
|-- Account Service
|-- Transaction Service
