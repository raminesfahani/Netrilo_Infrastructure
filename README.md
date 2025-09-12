# Netrilo Infrastructure

[![Build & Publish NuGet Packages](https://github.com/raminesfahani/Netrilo_Infrastructure/actions/workflows/nuget-packages.yml/badge.svg)](https://github.com/raminesfahani/Netrilo_Infrastructure/actions/workflows/nuget-packages.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Language](https://img.shields.io/github/languages/top/raminesfahani/Netrilo_Infrastructure)](https://github.com/raminesfahani/Netrilo_Infrastructure/search?l=c%23)

Netrilo is a .NET Core infrastructure library with multiple modules to simplify building microservices and enterprise applications.

[![Abstractions](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Abstractions)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Abstractions)
[![Bus](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Bus)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Bus)
[![Extensions](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Extensions)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Extensions)
[![Logging](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Logging)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Logging)
[![Persistence](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Persistence)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Persistence)
[![Web](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Web)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Web)




---

## Projects

| Project | Description |
|---------|-------------|
| [Infrastructure](./Src/Infrastructure/README.md) | Core infrastructure library for logging, DB, event bus, and pipelines. |
| [ServiceA](./Src/ServiceA/README.md) | Example microservice using Infrastructure module. |
| [ServiceB](./Src/ServiceB/README.md) | Another microservice showing event bus usage. |
| … | … |

---

## Getting Started

Check the README of each project for installation, usage, and configuration instructions.


## Features
These are mentioned common features such as below:
- Swagger Documentation
- CQRS
- Event Bus
- Pipeline Behaviour
- Database Repo
    - EfCore
        - SQL Server
        - Postgres
    - Mongo
    - Redis
- Event Store Database
- Logging
    - Elastic Search
    - Kibana
    - Apm
    - Serilog
- Message Brokers
    - RabbitMq
    - Kafka
    - Dapr
- Outbox Pattern
- Service Discovery and Healtch checking
    - Consul
    - Apm
- Docker Compose

## Sample and SourceCodes
