using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

public class CartControllerIntegrationTests : IClassFixture<WebApplicationFactory<MVC.Program>>
{
    private readonly HttpClient _client;

    public CartControllerIntegrationTests(WebApplicationFactory<MVC.Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task TestShopCart_ReturnsSuccessfully()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/ShopCart/");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
