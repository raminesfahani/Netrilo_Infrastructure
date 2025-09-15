# Netrilo.Infrastructure.Common.Web

> Part of the [Netrilo.Infrastructure](https://github.com/raminesfahani/Netrilo_Infrastructure) SDK

## 📦 NuGet

[![NuGet](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Web)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Web)

## 📖 Description

The `Netrilo.Infrastructure.Common.Web` package provides **ready-to-use extensions** for ASP.NET Core applications, bundling together common infrastructure concerns such as:

- 🚀 **Swagger/OpenAPI** with configuration from `appsettings.json`  
- 🧩 **FluentValidation** auto-registration (by reflection of provided assemblies)  
- 🛡 **Global exception handling** via `ExceptionFilter`  
- 📡 **Consul** for service discovery and health checks  
- 📊 **Application Insights** integration  
- ❤️ **Health checks** and telemetry  
- ⚡ **MediatR validation pipeline** (`ValidationBehavior<,>`)  
- 🔗 Automatic JSON enum serialization using `StringEnumConverter`  

---

## Installation

Add a project reference or NuGet package for `Netrilo.Infrastructure.Common.Web`.

```bash
dotnet add package Netrilo.Infrastructure.Common.Web
```

---

## Service Registration

The entry point is the **`AddCommonWeb`** method:

```csharp
builder.Services.AddCommonWeb(builder.Configuration, typeof(CreateUserValidator));
```

### What it does:
- Registers all validators in the provided assemblies (`params Type[] validatorTypes`)  
- Adds FluentValidation auto-validation and client-side adapters  
- Adds MVC with global `ExceptionFilter`  
- Configures Newtonsoft.Json enum serialization  
- Registers Swagger/OpenAPI  
- Registers health checks  
- Adds MediatR validation pipeline behavior  
- Adds Application Insights telemetry  

---

## Middleware Configuration

The unified entry point is **`UseCommonWeb`**:

```csharp
app.UseCommonWeb(builder.Configuration, app.Lifetime);
```

### What it does:
- Configures **Swagger UI** and OpenAPI docs  
- Registers service with **Consul** and sets up deregistration on shutdown (`IHostApplicationLifetime`)  
- Future-proof: additional middlewares (CORS, Telemetry, etc.) can be chained here  

---

## Example `Program.cs`

```csharp
using Netrilo.Infrastructure.Common.Web;

var builder = WebApplication.CreateBuilder(args);

// Register web infrastructure, validators, and common services
builder.Services.AddCommonWeb(builder.Configuration, typeof(CreateUserValidator));

var app = builder.Build();

// Configure request pipeline with Swagger + Consul + health checks
app.UseCommonWeb(builder.Configuration, app.Lifetime);

app.MapControllers();
app.Run();
```

---

## Swagger Configuration (appsettings.json)

```json
{
  "Swagger": {
    "Title": "My API",
    "Version": "v1",
    "Description": "API documentation powered by Swagger"
  },
  "Consul": {
    "ServiceId": "my-api-service",
    "ServiceName": "MyApi",
    "Host": "localhost",
    "Port": 5000,
    "ConsulAddress": "http://localhost:8500"
  },
  "ApplicationInsights": {
    "InstrumentationKey": "YOUR-KEY-HERE"
  }
}
```

---

## Health Checks

Adding health checks by decorating your services via using `AddCommonWeb` function will be automatically exposed via the configured health endpoint.

✅ This makes your web project **production-ready in just a few lines**.


## 📄 License

MIT License
