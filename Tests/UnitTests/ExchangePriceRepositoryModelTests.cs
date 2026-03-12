using exchange.platform.dal.abstractions.Models;
using Xunit;

namespace Tests.UnitTests;

public sealed class ExchangePriceRepositoryModelTests
{
    [Fact]
    public void CanCreateModel_WithAllRequiredProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var now = DateTime.UtcNow;

        // Act
        var model = new ExchangePriceRepositoryModel
        {
            Id              = id,
            PairName        = "BTCUSDT",
            ExchangeName    = "Binance",
            Price           = 123.45m,
            RetrievedAtUtc  = now
        };

        // Assert
        Assert.Equal(id, model.Id);
        Assert.Equal("BTCUSDT", model.PairName);
        Assert.Equal("Binance", model.ExchangeName);
        Assert.Equal(123.45m, model.Price);
        Assert.Equal(now, model.RetrievedAtUtc);
    }
}

