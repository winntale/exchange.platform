using Core.Abstractions;
using Core.Abstractions.Operations.Price;
using Core.Abstractions.Operations.Price.Queries;
using Microsoft.Extensions.DependencyInjection;
using Tests.Fixtures;
using Xunit;

namespace Tests.UnitTests;

public sealed class GetExchangePriceOperationErrorTests(CoreWithTestClientFixture fixture)
    : IClassFixture<CoreWithTestClientFixture>
{
    private readonly IServiceProvider _sp = fixture.ServiceProvider;

    [Fact]
    public async Task GetPriceAsync_WhenClientReturnsNull_ReturnsNotFoundError()
    {
        // Arrange
        var operation = _sp.GetRequiredService<IGetExchangePriceOperation>();

        var model = new GetExchangePriceOperationModel
        {
            PairName     = "BTCUSDT",
            ExchangeName = "NullExchangeClient"
        };

        // Act
        var result = await operation.GetExchangePriceAsync(model, CancellationToken.None);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.NotFound, result.Error.Type);
        Assert.Contains("BTCUSDT", result.Error.Message);
        Assert.Contains("NullExchangeClient", result.Error.Message);
    }
}

