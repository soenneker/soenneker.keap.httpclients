using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Keap.HttpClients.Abstract;
using Soenneker.Keap.HttpClients.Registrars;
using Soenneker.Tests.HostedUnit;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Keap.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class KeapOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IKeapOpenApiHttpClient _httpclient;

    public KeapOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IKeapOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Scoped_client_uses_scoped_cache()
    {
        var services = new ServiceCollection();

        services.AddKeapOpenApiHttpClientAsScoped();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor client = services.Single(descriptor => descriptor.ServiceType == typeof(IKeapOpenApiHttpClient));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
        await Assert.That(client.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }

    [Test]
    public async Task Singleton_client_uses_singleton_cache()
    {
        var services = new ServiceCollection();

        services.AddKeapOpenApiHttpClientAsSingleton();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor client = services.Single(descriptor => descriptor.ServiceType == typeof(IKeapOpenApiHttpClient));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
        await Assert.That(client.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
    }
}
