using TemplateFastEndpoints.API.Endpoints;

namespace TemplateFastEndpoints.API.E2E.Tests;

public class IndexEndpointTests : EndToEndTestCase
{
    protected override string Url => "/";

    [Fact]
    public async Task Should_Get_Information_Successfully()
    {
        // Arrange

        // Act
        var response = await Client.GetAsync(Url);
        var body = await response.Content.ReadFromJsonAsync<IndexResponse>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        body.Should().NotBeNull();
        body!.Message.Should().Be("Hello Fast Endpoints");
    }
}
