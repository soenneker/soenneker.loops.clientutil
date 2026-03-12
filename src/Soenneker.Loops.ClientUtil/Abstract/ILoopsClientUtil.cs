using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Loops.OpenApiClient;

namespace Soenneker.Loops.ClientUtil.Abstract;

/// <summary>
/// An async thread-safe singleton for Loops OpenApiClient
/// </summary>
public interface ILoopsClientUtil : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Gets a configured Loops.so OpenAPI client instance
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A configured Loops.so OpenAPI client</returns>
    ValueTask<LoopsOpenApiClient> Get(CancellationToken cancellationToken = default);
}