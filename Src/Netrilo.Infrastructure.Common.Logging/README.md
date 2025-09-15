# Netrilo.Infrastructure.Common.Logging

> Part of the [Netrilo.Infrastructure](https://github.com/raminesfahani/Netrilo_Infrastructure) SDK

## 📦 NuGet

[![NuGet](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Logging)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Logging)

---

## 📖 Overview

`Netrilo.Infrastructure.Common.Logging` provides **logging extensions** for .NET applications using **Serilog** and optional **Elastic APM** integration.  

It is designed to simplify the setup of structured logging, log enrichment, and distributed tracing in ASP.NET Core applications.

---

## ✨ Features

- ✅ Preconfigured **Serilog** logger:
  - Enrich logs with **context properties**.  
  - Enrich logs with **exception details**.  
  - Add **correlation ID** from request headers.  
  - Filter out noisy Swagger logs.  
  - Load configuration directly from `appsettings.json` / environment.  

- ✅ Seamless integration with **ASP.NET Core** logging.  
- ✅ Built-in **Elastic APM** setup with one line of code.  
- ✅ Extension methods for easy usage.  

---

## 🚀 Installation

If available on NuGet:

```bash
dotnet add package Netrilo.Infrastructure.Common.Logging
```

Or add a reference to your project.

---

## 📘 Usage

### 1. Configure Serilog Logger

```csharp
using Netrilo.Infrastructure.Common.Logging.Serilog;

var logger = LoggingExtensions.AddLogging(Configuration);
```

This will:
- Enrich logs with **context** and **exceptions**.  
- Add **correlation IDs** for request tracing.  
- Exclude Swagger logs.  
- Load settings from your `appsettings.json`.  

---

### 2. Add Elastic APM

```csharp
using Netrilo.Infrastructure.Common.Logging.Serilog;

builder.Services.AddApm();
```

This will integrate [Elastic APM](https://www.elastic.co/apm) for distributed tracing and performance monitoring.

---

### 3. Hook Into ASP.NET Core Pipeline

```csharp
using Netrilo.Infrastructure.Common.Logging.Serilog;

var app = builder.Build();

// Attach Serilog to ASP.NET Core’s logging pipeline
app.UseLogging(builder.Configuration, app.LoggerFactory);

app.Run();
```

---

## ⚙️ Example `appsettings.json`

```json
{
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File", "Serilog.Sinks.Elasticsearch" ],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "Enrich": [ "FromLogContext", "WithExceptionDetails", "WithCorrelationId" ],
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {CorrelationId} {Message:lj}{NewLine}{Exception}"
        }
      },
      {
        "Name": "File",
        "Args": {
          "path": "Logs/log-.txt",
          "rollingInterval": "Day",
          "retainedFileCountLimit": 14,
          "shared": true
        }
      },
      {
        "Name": "Elasticsearch",
        "Args": {
          "nodeUris": "http://localhost:9200",
          "indexFormat": "myapp-logs-{0:yyyy.MM}",
          "autoRegisterTemplate": true,
          "autoRegisterTemplateVersion": "ESv7"
        }
      }
    ]
  },
  "ElasticApm": {
    "ServerUrls": "http://localhost:8200",
    "ServiceName": "MyApp.Service",
    "Environment": "Development",
    "SecretToken": "",
    "TransactionSampleRate": 1.0
  }
}
```

---

## 📦 Provided Extension Methods

| Method | Description |
|--------|-------------|
| `AddLogging(IConfiguration)` | Creates and configures a Serilog `Logger` with enrichment and filters. |
| `AddApm()` | Adds Elastic APM to the application services. |
| `UseLogging(IConfiguration, ILoggerFactory)` | Connects Serilog to ASP.NET Core’s logging pipeline. |

---

## 🧪 Tests

Run the following command to run the tests:

```
dotnet test .\Tests\Netrilo.Infrastructure.Common.Logging.UnitTests\Netrilo.Infrastructure.Common.Logging.UnitTests.csproj
```

## 📄 License

MIT License
