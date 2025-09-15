# Netrilo.Infrastructure.Common.Persistence

> Part of the [Netrilo.Infrastructure](https://github.com/raminesfahani/Netrilo_Infrastructure) SDK

## 📦 NuGet

[![NuGet](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Persistence)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Persistence)

## 📖 Description

A modular persistence library for **.NET 8/9** applications.  
Provides a unified repository pattern and configuration utilities for working with **SQL (EF Core: PostgreSQL & SQL Server)**, **MongoDB**, and **Redis** in a clean and extensible way.

---

## ✨ Features

- **Entity Framework Core Repository**
  - Generic repository pattern (`EfCoreRepository<T>`)
  - Async CRUD operations
  - Owned entity change detection (`HasChangedOwnedEntities`)
  - Built-in provider support:
    - ✅ **PostgreSQL**
    - ✅ **SQL Server**
  - EF Core registration via **`EfCoreDbOptions`** loaded from configuration

- **MongoDB Repository**
  - Generic repository (`MongoRepository<T>`)
  - Documents must implement **`IDocument`**
  - CRUD, bulk ops, and LINQ queries
  - Configured via `MongoDbSettings`

- **Redis Repository**
  - Generic repository (`IRedisRepository<T>`)
  - Cache and persistence operations
  - Configured via `RedisSettings`

---

## 🚀 Usage

### 1. EF Core Setup

#### appsettings.json (PostgreSQL)

```json
{
  "EfCore": {
    "DatabaseType": "Postgres",
    "ConnectionString": "Host=localhost;Database=MyAppDb;Username=myuser;Password=mypassword"
  }
}
```

#### appsettings.json (SQL Server)

```json
{
  "EfCore": {
    "DatabaseType": "SqlServer",
    "ConnectionString": "Server=.;Database=MyAppDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

#### Program.cs

```csharp
using Netrilo.Infrastructure.Common.Persistence.Sql.EfCore;

builder.Services.AddEfCore<MyDbContext>(builder.Configuration.GetSection("EfCore"));

// Later in Program.cs
app.UseEfCore();
```

---

### 2. EF Core Repository Example

```csharp
public class UserService
{
    private readonly IEfCoreRepository<User> _repository;

    public UserService(IEfCoreRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<User?> GetUserAsync(Guid id) =>
        await _repository.GetByIdAsync(id);

    public async Task AddUserAsync(User user)
    {
        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();
    }
}
```

---

### 3. MongoDB Setup

#### appsettings.json

```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "MyDatabase"
  }
}
```

#### Program.cs

```csharp
using Netrilo.Infrastructure.Common.Persistence.NoSql.Mongo;

builder.Services.AddMongoDb(builder.Configuration.GetSection("MongoDbSettings"));
```

#### Product Document

```csharp
using Netrilo.Infrastructure.Common.Persistence.NoSql.Mongo.Documents;

public class Product : IDocument
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Custom fields
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
```

#### Service

```csharp
public class ProductService
{
    private readonly IMongoRepository<Product> _repository;

    public ProductService(IMongoRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task AddProduct(Product product) =>
        await _repository.InsertAsync(product);

    public async Task<List<Product>> GetAllProducts() =>
        await _repository.FilterBy(_ => true).ToListAsync();
}
```

---

### 4. Redis Setup

#### appsettings.json

```json
{
  "RedisSettings": {
    "ConnectionString": "localhost:6379",
    "DefaultDatabase": 0
  }
}
```

#### Program.cs

```csharp
using Netrilo.Infrastructure.Common.Persistence.NoSql.Redis;

builder.Services.AddRedis(builder.Configuration.GetSection("RedisSettings"));
```

#### Usage

```csharp
public class CacheService
{
    private readonly IRedisRepository<string> _cache;

    public CacheService(IRedisRepository<string> cache)
    {
        _cache = cache;
    }

    public async Task CacheValue(string key, string value) =>
        await _cache.SetAsync(key, value);

    public async Task<string?> GetValue(string key) =>
        await _cache.GetAsync(key);
}
```

---

## 📄 License

MIT License
