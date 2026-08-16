using Soenneker.Keap.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

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
}
