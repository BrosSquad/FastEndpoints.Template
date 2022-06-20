using FastEndpointsAPI.Endpoints;

namespace FastEndpointsAPI.E2E.Tests;

public class IndexEndpointTests : EndToEndTestCase
{
    protected override string Url => "/";

    [Fact]
    public async Task Should_Get_Information_Successfully()
    {
        // Arrange

        // Act
        var response = await Client.GetAsync(Url);
        var (status, body) = await response.Extract<IndexResponse>();

        // Assert
        status.Should().Be(System.Net.HttpStatusCode.OK);
        body.Should().NotBeNull();
        body.Message.Should().Be("Hello Fast Endpoints");
    }
}
