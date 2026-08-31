[![](https://img.shields.io/nuget/v/soenneker.cloudinary.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudinary.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudinary.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cloudinary.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cloudinary.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudinary.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudinary.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cloudinary.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Cloudinary.OpenApiClient

A Kiota-generated .NET client exposing Cloudinary's typed OpenAPI request builders and models.

## Installation

```bash
dotnet add package Soenneker.Cloudinary.OpenApiClient
```

## Recommended setup

Most applications should use `Soenneker.Cloudinary.OpenApiClientUtil`, which configures authentication, the API base URL, client reuse, and dependency injection:

```csharp
using Soenneker.Cloudinary.OpenApiClientUtil.Registrars;

services.AddCloudinaryOpenApiClientUtilAsSingleton();
```

Resolve `ICloudinaryOpenApiClientUtil` and call `Get` to obtain `CloudinaryOpenApiClient`.

## Direct construction

Use the generated package directly when the application already owns its Kiota authentication and HTTP pipeline:

```csharp
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Cloudinary.OpenApiClient;
using System.Net.Http.Headers;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://api.cloudinary.com")
};

httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", apiToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient)
{
    BaseUrl = httpClient.BaseAddress.ToString().TrimEnd('/')
};

var client = new CloudinaryOpenApiClient(adapter);
```

Choose the authorization scheme and base URL required by the Cloudinary API represented by the operation you call; the generated client does not acquire credentials.

The root exposes `V1_1` and `V2` request builders. Responses, request bodies, errors, and union payloads use generated model types, and nullable return values represent endpoints that may return no body.

## Generated-code boundary

This package follows Cloudinary's schema closely and may change when that schema changes. Prefer request builders and model properties over manually assembled paths or JSON. Do not hand-edit generated source files; place application-specific validation, retries, and policy around the client or in a separate utility.
