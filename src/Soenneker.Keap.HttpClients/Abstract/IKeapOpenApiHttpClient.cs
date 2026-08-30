using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
namespace Soenneker.Keap.HttpClients.Abstract;

/// <summary>
/// Provides a cached HTTP client configured for the Keap REST API.
/// </summary>
public interface IKeapOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the HTTP client cached for this provider's lifetime.
    /// </summary>
    /// <param name="cancellationToken">Stops client creation if the cached instance has not been created yet.</param>
    /// <returns>The client configured with Keap's base address and authorization header.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
