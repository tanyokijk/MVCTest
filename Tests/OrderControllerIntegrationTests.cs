using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;
public class OrderControllerIntegrationTests : IClassFixture<WebApplicationFactory<MVC.Program>>
{
    private readonly HttpClient _client;

    public OrderControllerIntegrationTests(WebApplicationFactory<MVC.Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task TestOrderCheckout_ReturnsSuccessfully()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/Order/Checkout");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestOrderComplete_ReturnsSuccessfully()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/Order/Complete");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}