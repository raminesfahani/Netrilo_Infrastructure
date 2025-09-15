# Netrilo.Infrastructure.Common.Extensions

> Part of the [Netrilo.Infrastructure](https://github.com/raminesfahani/Netrilo_Infrastructure) SDK

## 📦 NuGet

[![NuGet](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Extensions)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Extensions)

## 📖 Overview
`Netrilo.Infrastructure.Common.Extensions` is a collection of **extension methods**, **utilities**, **validators**, and **infrastructure helpers** for .NET applications.  

It provides ready-to-use helpers for:
- String manipulation (case conversions, hashing)
- Object → QueryString conversion
- Path utilities
- JSON converters
- Environment variable handling
- Strongly typed settings
- Logging
- Input validation (e.g., mobile numbers)
- ...

---

## ✨ Features

### 🔧 Extensions
- **ByteArray**
  - `Sha256`: Compute SHA-256 hash for byte arrays.  
- **Object**
  - `QueryString`: Convert objects into query string format.  
- **String**
  - `ToCamelCase`, `ToPascalCase`, `ToSnakeCase`, `ToKebabCase`, `ToTrainCase`.  
  - `Sha256`: Compute SHA-256 hash from a string.  
  - `StringExtensions`: Additional helpers for null/empty checks and transformations.  

### 🛠 Path Utilities
- `PathUtilitiesExtension`: Normalize and validate file paths.  
- Custom exception: `InvalidDirectorySeperatorCharException`.  

### ⚙️ Settings
- `AppSettingsBase`: Base class for strongly-typed app settings.  
- Interfaces: `IAppSettings`, `IGlobalSettings`, `IWorkerSettings`.  

### 📝 Tools
- **DotEnv** loader for environment variables (`.env` files).  
- `[EnvName]` attribute for mapping environment variables to properties.  
- Exceptions for missing environment variables.  

### 🧾 JSON Converters
- `MailAddressConverter`: JSON support for `System.Net.Mail.MailAddress`.  

### 🪵 Logger
- `AppLogger`: lightweight structured logger for apps and services.  

### ✅ Validators
- `ValidationBase.IsValidMobileNumber(ulong)`: Validates international mobile numbers using **libphonenumber-csharp**.  

---

## 🚀 Getting Started

### Prerequisites
- .NET 8.0+ or .Net Standard 2.0

### Installation
Install from NuGet:
```bash
dotnet add package Netrilo.Infrastructure.Common.Extensions
```

Or reference the project in your solution.  

---

## 📘 Usage Examples

### 🔑 String Case Conversions
```csharp
using Netrilo.Infrastructure.Common.Extensions.String;

"hello world".ToCamelCase();   // "helloWorld"
"hello world".ToPascalCase();  // "HelloWorld"
"hello world".ToSnakeCase();   // "hello_world"
"hello world".ToKebabCase();   // "hello-world"
"hello world".ToTrainCase();   // "Hello-World"
```

### 🔑 Hashing
```csharp
using Netrilo.Infrastructure.Common.Extensions.String;

string password = "Secret123";
string hash = password.ToSha256();
```

```csharp
using Netrilo.Infrastructure.Common.Extensions.ByteArray;

byte[] data = Encoding.UTF8.GetBytes("Hello");
string hash = data.ToSha256();
```

### 🔑 Object → Query String
```csharp
using Netrilo.Infrastructure.Common.Extensions.Object;

var user = new { Name = "Alice", Age = 30 };
string qs = user.ToQueryString();
// "Name=Alice&Age=30"
```

### 🔑 Path Utilities
```csharp
using Netrilo.Infrastructure.Common.Extensions.PathUtilities;

string path = "C:/invalid\\path";
string normalized = path.NormalizeDirectorySeparators();
```

### 🔑 Settings
```csharp
public class DbSettings : AppSettingsBase, IAppSettings
{
    public string ConnectionString { get; set; }
}
```

### 🔑 Environment Variables
```csharp
using Netrilo.Infrastructure.Common.Extensions.Tools;

DotEnv.Load(".env");
string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
```

With annotations:
```csharp
public class DbConfig
{
    [EnvName("DB_HOST")]
    public string Host { get; set; }
}
```

### 🔑 JSON Converter
```csharp
var options = new JsonSerializerOptions();
options.Converters.Add(new MailAddressConverter());

var mail = new MailAddress("user@example.com");
string json = JsonSerializer.Serialize(mail, options);
```

### 🔑 Logger
```csharp
var logger = new AppLogger();
logger.Info("Application started");
logger.Error("Unexpected error", ex);
```

### ✅ Validators
```csharp
using Netrilo.Infrastructure.Common.Extensions.Validators;

ulong number = 14155552671; // US number
bool valid = ValidationBase.IsValidMobileNumber(number);
Console.WriteLine(valid); // true if valid
```

---

## 🧪 Tests

Run the following command to run the tests:

```
dotnet test .\Tests\Netrilo.Infrastructure.Common.Extensions.UnitTests\Netrilo.Infrastructure.Common.Extensions.UnitTests.csproj
```


## 📄 License

MIT License
