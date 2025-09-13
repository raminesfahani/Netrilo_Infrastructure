# Netrilo.Infrastructure.Common.Bus

> Part of the [Netrilo.Infrastructure](https://github.com/raminesfahani/Netrilo_Infrastructure) SDK

## 📦 NuGet

[![NuGet](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Bus)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Bus)

## 📖 Description

Implements an in-memory or pluggable event bus for domain event publishing.

- Event Stores for event driven systems including stores, projection, and snapshot
- Event Bus supporting query and command handlers
- Implementing Message Brokers with MassTransit supporting RabbitMQ, Azure Service Bus, and Kafka
- Supporting Domain-Driven-Design architecture like aggregates and projection
- Simple pub/sub for decoupled messaging
- Supports mediator patterns for `Clean Architecture Design`
- Designed for testability

## 🚀 Installation

```bash
dotnet add package Netrilo.Infrastructure.Common.Bus
```

---

## 🧩 Bus Extension 

Firstly, add this namespace in your code:
```csharp
using Netrilo.Infrastructure.Common.Bus;
```

Then, simply register the Event Bus and mapping profiles including all AddMediatR and mapper assemblies like the following code in your program `Startup`:
```csharp
services.AddCore(typeof(Startup));
```

If you have multiple dependent projects including assemblies need to be registered, this function can be overloaded by multiple optional arguments like following code:
```csharp
services.AddCore(typeof(Startup), typeof(ChildProject1), typeof(ChildProject2), ...);
```

Finally, you will have the access to the following services over DI:

- ICommandBus
- IQueryBus
- IEventBus

### Sample Usage
```csharp
eventBus.Publish(new OrderCreatedEvent(...));
```

---

## 🧩 Event Store Extension 

Event Store part supports `Domain-Driven-Design` and `Event-Driven` systems with supporting different storages.

To use the event stores extension, firstly add this namespace in your code:
```csharp
using Netrilo.Infrastructure.Common.Bus.EventStores;
```

Then, simply register the Event Store like the following code in your program `Startup`:
```csharp
services.AddEventStore<TAggregate>(IConfiguration Configuration, Action<DbContextOptionsBuilder> dbContextOptions = null);
```
This Event Store supports multiple stores including:

- EfCore
- Mongo

Which you can configure in `EventStoresOptions` variables in `appsettings.json`.

---

## 🧪 Tests

```
dotnet test .\Tests\Netrilo.Infrastructure.Common.Bus.UnitTests\Netrilo.Infrastructure.Common.Bus.UnitTests.csproj
```
