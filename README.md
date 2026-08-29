[![](https://img.shields.io/nuget/v/soenneker.keap.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.keap.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.keap.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.keap.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.keap.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.keap.httpclients/)

# Soenneker.Keap.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Keap.HttpClients
```

## Quick start

```csharp
using Soenneker.Keap.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddKeapOpenApiHttpClientAsSingleton();
```

Adds `KeapOpenApiHttpClient` as a singleton service.

## What you get

- `IKeapOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `KeapOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `KeapOpenApiHttpClientRegistrar.AddKeapOpenApiHttpClientAsSingleton(services)` | Adds `KeapOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `KeapOpenApiHttpClientRegistrar.AddKeapOpenApiHttpClientAsScoped(services)` | Adds `KeapOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
