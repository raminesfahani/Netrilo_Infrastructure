# Netrilo.Infrastructure

[![Build](https://github.com/raminesfahani/Netrilo_Infrastructure/actions/workflows/dotnet.yml/badge.svg)](https://github.com/raminesfahani/Netrilo_Infrastructure/actions)
[![License](https://img.shields.io/github/license/raminesfahani/Netrilo_Infrastructure)](LICENSE)

**Netrilo.Infrastructure** is a modular infrastructure SDK for modern .NET applications.  
It provides plug-and-play building blocks for common concerns like logging, persistence, web layers, messaging, and extensions — all in a clean, testable, and highly maintainable architecture.

---

## 📚 Table of Contents

- [About the Project](#about-the-project)
- [Architecture Overview](#architecture-overview)
- [NuGet Packages](#nuget-packages)
- [Installation](#installation)
- [Build Instructions](#build-instructions)
- [Repository Structure](#repository-structure)
- [Contribution Guide](#contribution-guide)
- [License](#license)

---

## 📖 About the Project

This repository is the backbone of the `Netrilo` infrastructure layer, designed to be:

- 🔌 **Modular**: Use only what you need.
- 🧪 **Testable**: Fully decoupled, allowing unit testing and mocking.
- ♻️ **Reusable**: Drop into any .NET Core / .NET 6+ project.
- 🔍 **Discoverable**: Each module has its own documentation and NuGet package.

---

## 🧱 Architecture Overview

Each module targets a specific infrastructure concern:

| Layer | Purpose |
|------|---------|
| Abstractions | Core contracts and DI service definitions |
| Bus         | Event bus & messaging pattern implementation |
| Extensions  | Common helper utilities and extension methods |
| Logging     | Structured logging setup using Serilog |
| Persistence | EF Core integration, repository pattern, migrations |
| Web         | API filters, model binding, controller base logic |

These modules can be installed independently and used in isolation or together.

---

## 📦 NuGet Packages

| Module | NuGet |
|--------|-------|
| **Abstractions** | [![Abstractions](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Abstractions)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Abstractions) |
| **Bus** | [![Bus](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Bus)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Bus) |
| **Extensions** | [![Extensions](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Extensions)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Extensions) |
| **Logging** | [![Logging](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Logging)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Logging) |
| **Persistence** | [![Persistence](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Persistence)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Persistence) |
| **Web** | [![Web](https://img.shields.io/nuget/v/Netrilo.Infrastructure.Common.Web)](https://www.nuget.org/packages/Netrilo.Infrastructure.Common.Web) |

---

## 🚀 Installation

You can install any package using the NuGet CLI or `.NET CLI`:

```bash
dotnet add package Netrilo.Infrastructure.Common.Logging
```

To use GitHub Packages:

```bash
dotnet nuget add source \
  --name github \
  https://nuget.pkg.github.com/raminesfahani/index.json \
  --username raminesfahani \
  --password <YOUR_PERSONAL_ACCESS_TOKEN>
```

---

## 🛠️ Build Instructions

To build all projects and generate NuGet packages:

```bash
dotnet restore
dotnet build --configuration Release
dotnet pack --configuration Release --output ./artifacts
```

To push to GitHub Packages:

```bash
dotnet nuget push ./artifacts/*.nupkg \
  --source "https://nuget.pkg.github.com/raminesfahani/index.json" \
  --api-key <GITHUB_TOKEN> \
  --skip-duplicate
```

---

## 🗂️ Repository Structure

```
Src/
├── Infrastructure.Common.Abstractions/
├── Infrastructure.Common.Bus/
├── Infrastructure.Common.Extensions/
├── Infrastructure.Common.Logging/
├── Infrastructure.Common.Persistence/
└── Infrastructure.Common.Web/
.github/
├── workflows/
│   └── dotnet.yml     → CI/CD pipeline
artifacts/              → Generated NuGet packages
```

Each folder contains its own README and is published as a standalone NuGet package.

---

## 🤝 Contribution Guide

We welcome contributions to improve and extend the SDK.  
To contribute:

1. Fork the repo and create your feature branch.
2. Commit your changes and push.
3. Open a pull request.

> Ensure your changes follow the coding standards and are covered by unit tests.

---

## 🔒 License

This project is licensed under the [MIT License](LICENSE).

---

## 📬 Contact

Maintained by [@raminesfahani](https://github.com/raminesfahani).  
For feature requests or bug reports, please [open an issue](https://github.com/raminesfahani/Netrilo_Infrastructure/issues).
