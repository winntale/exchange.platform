using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using exchange.platform.binance.ExchangeClients;
using exchange.platform.clients.abstractions.Models;
using exchange.platform.clients.abstractions.Providers;
using Moq;
using Moq.Protected;
using Xunit;

namespace Tests.UnitTests;

public sealed class BinancePriceExchangeClientTests
{
    [Fact]
    public async Task GetPriceQueryAsync_WhenResponseIsSuccessful_ReturnsPriceExchangeModel()
    {
        // Arrange
        var expectedSymbol = "BTCUSDT";
        var expectedPrice  = 10m;

        var messageHandler = new Mock<HttpMessageHandler>();

        messageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync((HttpRequestMessage request, CancellationToken _) =>
            {
                var model = new PriceExchangeModel
                {
                    Symbol = expectedSymbol,
                    Price  = expectedPrice
                };

                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = JsonContent.Create(model)
                };

                return response;
            });

        var httpClient = new HttpClient(messageHandler.Object)
        {
            BaseAddress = new Uri("https://api.binance.com")
        };

        var httpClientFactory = new Mock<IHttpClientFactory>();
        httpClientFactory
            .Setup(f => f.CreateClient("Binance"))
            .Returns(httpClient);

        var client = new BinancePriceExchangeClient(httpClientFactory.Object);

        var requestModel = new GetPriceExchangeModel
        {
            Symbol = expectedSymbol
        };

        // Act
        var result = await client.GetPriceQueryAsync(requestModel, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedSymbol, result!.Symbol);
        Assert.Equal(expectedPrice, result.Price);
    }
}

