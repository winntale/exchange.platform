using Core.Abstractions.Operations.Price;
using Core.Abstractions.Operations.Price.Queries;
using Microsoft.Extensions.DependencyInjection;
using Tests.Fixtures;
using Xunit;

namespace Tests.UnitTests;

public sealed class GetExchangePriceOperationTests(CoreWithTestClientFixture fixture)
    : IClassFixture<CoreWithTestClientFixture>
{
    private readonly IServiceProvider _sp = fixture.ServiceProvider;

    [Fact]
    public async Task GetPriceAsync_WhenCalledWithBinance_ReturnsOne()
    {
        // Arrange
        var operation = _sp.GetRequiredService<IGetExchangePriceOperation>();
        
        var model = new GetExchangePriceOperationModel
        {
            PairName     = "BTCUSDT",
            ExchangeName = "TestExchangeClient"
        };

        // Act
        var result = await operation.GetExchangePriceAsync(model, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(1m, result.Value.Price);
    }
    
}