# Netrilo.Infrastructure.Common.Bus

> Part of the [Netrilo.Infrastructure](https://github.com/raminesfahani/Netrilo_Infrastructure) SDK

## 📦 NuGet

[![NuGet](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Bus)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Bus)

## 📖 Description

Implements an in-memory or pluggable event bus for domain event publishing.

- Simple pub/sub for decoupled messaging
- Supports mediator patterns
- Designed for testability

## 🚀 Installation

```bash
dotnet add package Netrilo.Infrastructure.Common.Bus
```

## 🧩 Usage

```csharp
eventBus.Publish(new OrderCreatedEvent(...));
```

## 🧪 Tests

```
Tests/Infrastructure.Common.Bus.Tests/
```

## 📄 License

MIT License
