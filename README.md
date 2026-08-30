[![](https://img.shields.io/nuget/v/soenneker.keap.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.keap.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.keap.httpclients/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.keap.httpclients/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.keap.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.keap.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.keap.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.keap.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.keap.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.keap.httpclients/actions/workflows/codeql.yml)

# Soenneker.Keap.HttpClients

Provides a cached `HttpClient` configured for Keap's REST API and OAuth access token.

## Install

```bash
dotnet add package Soenneker.Keap.HttpClients
```

## Configuration

```json
{
  "Keap": {
    "AccessToken": "<OAuth access token>"
  }
}
```

`AccessToken` is required. The default base address is `https://api.infusionsoft.com/crm`, and the token is sent as `Authorization: Bearer {token}`.

For another environment or authentication gateway, set `Keap:ClientBaseUrl`, `Keap:AuthHeaderName`, or `Keap:AuthHeaderValueTemplate`. The value template must contain `{token}` where the configured access token belongs.

## Register and use

```csharp
using Soenneker.Keap.HttpClients.Abstract;
using Soenneker.Keap.HttpClients.Registrars;

services.AddKeapOpenApiHttpClientAsSingleton();

IKeapOpenApiHttpClient provider =
    serviceProvider.GetRequiredService<IKeapOpenApiHttpClient>();

HttpClient client = await provider.Get(cancellationToken);
using HttpResponseMessage response = await client.GetAsync(
    "v2/contacts",
    cancellationToken);

response.EnsureSuccessStatusCode();
```

`Get()` creates the client on first use and reuses it for the provider's lifetime. Configuration is applied during that first creation; replace the provider to pick up changed credentials or endpoints.

`AddKeapOpenApiHttpClientAsScoped()` creates an independent cache and client for each dependency-injection scope. Disposing one scope cannot remove another scope's client. Let the container dispose the provider, and do not dispose the returned cached `HttpClient` directly.
