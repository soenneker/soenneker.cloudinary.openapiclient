using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cloudinary.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CloudinaryOpenApiClientTests : HostedUnitTest
{
    public CloudinaryOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
