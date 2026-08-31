[![](https://img.shields.io/nuget/v/soenneker.loops.clientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.loops.clientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.loops.clientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.loops.clientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.loops.clientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.loops.clientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.loops.clientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.loops.clientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Loops.ClientUtil

Create and reuse an authenticated Loops generated client over the shared HTTP transport.

## Install

```bash
dotnet add package Soenneker.Loops.ClientUtil
```

## Configure and register

```json
{ "Loops": { "ApiKey": "<API key>" } }
```

```csharp
services.AddLoopsClientUtilAsScoped();
```

The scoped utility deliberately keeps `ILoopsHttpClient` singleton. Disposing a scope releases its generated-client wrapper without tearing down the transport used by later scopes. Use the singleton registration when the wrapper should also live for the application lifetime.

```csharp
LoopsOpenApiClient client = await clientUtil.Get(cancellationToken);
```

Follow the generated request builders from `client` to contacts, events, transactional email, and mailing-list operations. Authentication is supplied by the underlying HTTP provider, so Kiota does not add a second bearer header. Let the service container dispose the utility and provider.
