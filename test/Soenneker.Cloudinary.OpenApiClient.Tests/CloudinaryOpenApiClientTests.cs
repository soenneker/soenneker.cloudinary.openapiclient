using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cloudinary.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class CloudinaryOpenApiClientTests : FixturedUnitTest
{
    public CloudinaryOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
