using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
using MVC;

namespace MVC.Tests;

public class CarsControllerIntegrationTests : IClassFixture<WebApplicationFactory<MVC.Program>>
{
    private readonly HttpClient _client;

    public CarsControllerIntegrationTests(WebApplicationFactory<MVC.Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task TestDeleteCar_ReturnsSuccessfully()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/Cars/Delete");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestAddCar_ReturnsSuccessfully()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/Cars/Add");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestListCar_ReturnsSuccessfully()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/Cars/List");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }
    [Fact]
    public async Task TestListCategoryElectroCar_ReturnsSuccessfully()
    {
        // Arrange
        var category = "electro";
        var request = new HttpRequestMessage(HttpMethod.Get, $"/Cars/List/{category}");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestListCategoryElectroCar_ReturnsFailet()
    {
        // Arrange
        var category = "electroauto";
        var request = new HttpRequestMessage(HttpMethod.Get, $"/Cars/List/{category}");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        Assert.False(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task TestListCategoryFuelCar_ReturnsSuccessfully()
    {
        // Arrange
        var category = "fuel";
        var request = new HttpRequestMessage(HttpMethod.Get, $"/Cars/List/{category}");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task TestListCategoryFuelCar_ReturnsFailet()
    {
        // Arrange
        var category = "fuelauto";
        var request = new HttpRequestMessage(HttpMethod.Get, $"/Cars/List/{category}");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        Assert.False(response.IsSuccessStatusCode);
    }
}
