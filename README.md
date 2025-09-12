# Netrilo Infrastructure

[![Build Status](https://img.shields.io/github/actions/workflow/status/raminesfahani/Netrilo_Infrastructure/dotnet-core.yml?branch=main)](https://github.com/raminesfahani/Netrilo_Infrastructure/actions)
[![License](https://img.shields.io/github/license/raminesfahani/Netrilo_Infrastructure)](LICENSE)

Netrilo_Infrastructure is a .NET Core infrastructure library with multiple modules to simplify building microservices and enterprise applications.

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
