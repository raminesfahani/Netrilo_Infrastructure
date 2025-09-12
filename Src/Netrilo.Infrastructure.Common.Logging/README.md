# Netrilo.Infrastructure.Common.Logging

> Part of the [Netrilo.Infrastructure](https://github.com/raminesfahani/Netrilo_Infrastructure) SDK

## 📦 NuGet

[![NuGet](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Logging)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Logging)

## 📖 Description

Sets up logging using [Serilog](https://serilog.net) with default sinks and enrichers.

- Console, File, Seq sinks
- Correlation ID tracking
- Request/response logging middleware

## 🚀 Installation

```bash
dotnet add package Netrilo.Infrastructure.Common.Logging
```

## 🧩 Usage

```csharp
builder.Logging.AddNetriloLogging(config => { ... });
```

## 🧪 Tests

```
Tests/Infrastructure.Common.Logging.Tests/
```

## 📄 License

MIT License
