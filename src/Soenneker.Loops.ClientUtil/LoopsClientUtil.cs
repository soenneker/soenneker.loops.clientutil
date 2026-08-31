using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Loops.Client.Abstract;
using Soenneker.Loops.ClientUtil.Abstract;
using Soenneker.Loops.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Loops.ClientUtil;

public sealed class LoopsClientUtil : ILoopsClientUtil
{
    private readonly AsyncSingleton<LoopsOpenApiClient> _client;
    private readonly ILoopsHttpClient _httpClientUtil;

    public LoopsClientUtil(ILoopsHttpClient httpClientUtil)
    {
        _httpClientUtil = httpClientUtil;
        _client = new AsyncSingleton<LoopsOpenApiClient>(CreateClient);
    }

    private async ValueTask<LoopsOpenApiClient> CreateClient(CancellationToken token)
    {
        HttpClient httpClient = await _httpClientUtil.Get(token).NoSync();

        var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

        return new LoopsOpenApiClient(requestAdapter);
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
