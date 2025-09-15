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

Event Store extension supports `Domain-Driven-Design` and `Event-Driven` systems with supporting different storages.

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

## 🧩 Message Brokers Extensions

Message brokers part works with `MassTransit` and handles the `Event Messaging` and `Message Delivering` via `EventBus` and `Event Listener` between the endpoints, and supports multiple type of `MessageBroker`, including:

- RabbitMQ
- AzureServiceBus
- Kafka

Which you can configure in `MessageBrokersOptions` variables in `appsettings.json`. Additionally, you have all features and functionalities of MassTransit to work with (read the full documentation of *MassTransit* in [This link](https://masstransit.io/documentation/)).

### 🧩 Message Brokers Installation

You can easily register mentioned MessageBrokers by an overloaded function named `AddMessageBroker` in your project `Startup` as the following code:

**Configure RabbitMQ and Kafka**

```
services.AddMessageBroker(
            IConfiguration Configuration,
            Type[] consumers,
            Action<IBusRegistrationConfigurator> busRegistrationConfigurator = null,
            Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> rabbitMqBusFactoryConfigurator = null
            )
```


**Configure AzureServiceBus**

```
services.AddMessageBroker(
            IConfiguration Configuration,
            Type[] consumers,
            Action<IBusRegistrationConfigurator> busRegistrationConfigurator = null,
            Action<IBusRegistrationContext, IServiceBusBusFactoryConfigurator> azureBusFactoryConfigurator = null
            )
```

In addition, you can get and register all `Consumers` by reflection to register as the following code:

```
services.AddMessageBroker(Configuration, ConsumersExtension.All(), default)
```

This will register the considered message broker and Event Listener to publish messages and events to the consumers and endpoints by injection of `IEventListener` and use that like the following function:

```
public async Task PublishOrderCreated
    {
        eventListener.Publish<OrderCreatedEvent>(new OrderCreatedEvent());
    }

```

The property `eventListener` is type of `IEventListener` which should be injected in your class constructor and `OrderCreatedEvent` must be type of `IEvent`.

---

## 🧪 Tests

Run the following command to run the tests:

```
dotnet test .\Tests\Netrilo.Infrastructure.Common.Bus.UnitTests\Netrilo.Infrastructure.Common.Bus.UnitTests.csproj
```
