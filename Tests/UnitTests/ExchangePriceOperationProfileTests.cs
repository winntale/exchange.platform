using AutoMapper;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.core;
using exchange.platform.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.UnitTests;

public sealed class ExchangePriceOperationProfileTests
{
    private readonly IMapper _mapper;

    public ExchangePriceOperationProfileTests()
    {
        var services = new ServiceCollection();
        services.ConfigureAutoMapper();

        var provider = services.BuildServiceProvider();
        _mapper = provider.GetRequiredService<IMapper>();
    }

    [Fact]
    public void Mapping_GetExchangePriceOperationModel_To_GetPriceExchangeModel_MapsSymbolFromPairName()
    {
        // Arrange
        var source = new GetExchangePriceOperationModel
        {
            PairName     = "ETHUSDT",
            ExchangeName = "AnyExchange"
        };

        // Act
        var destination = _mapper.Map<exchange.platform.clients.abstractions.Models.GetPriceExchangeModel>(source);

        // Assert
        Assert.Equal(source.PairName, destination.Symbol);
    }
}

