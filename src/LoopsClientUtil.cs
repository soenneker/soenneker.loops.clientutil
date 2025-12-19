using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Kiota.BearerAuthenticationProvider;
using Soenneker.Loops.Client.Abstract;
using Soenneker.Loops.ClientUtil.Abstract;
using Soenneker.Loops.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Loops.ClientUtil;

/// <inheritdoc cref="ILoopsClientUtil"/>
public sealed class LoopsClientUtil : ILoopsClientUtil
{
    private readonly AsyncSingleton<LoopsOpenApiClient> _client;

    public LoopsClientUtil(ILoopsHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<LoopsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Loops:ApiKey");

            var requestAdapter = new HttpClientRequestAdapter(new BearerAuthenticationProvider(apiKey), httpClient: httpClient);

            return new LoopsOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<LoopsOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}