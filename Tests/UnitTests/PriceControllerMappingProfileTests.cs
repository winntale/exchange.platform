using AutoMapper;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.GatewayModelsMappingProfiles;
using exchange.platform.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.UnitTests;

public sealed class PriceControllerMappingProfileTests
{
    private readonly IMapper _mapper;

    public PriceControllerMappingProfileTests()
    {
        var services = new ServiceCollection();
        services.AddAutoMapper(cfg => cfg.AddProfile<PriceControllerMappingProfile>());

        var provider = services.BuildServiceProvider();
        _mapper = provider.GetRequiredService<IMapper>();
    }

    [Fact]
    public void Mapping_GetExchangePriceDto_To_GetExchangePriceOperationModel_MapsAllFields()
    {
        // Arrange
        var source = new GetExchangePriceDto
        {
            PairName     = "BTCUSDT",
            ExchangeName = "Binance"
        };

        // Act
        var destination = _mapper.Map<GetExchangePriceOperationModel>(source);

        // Assert
        Assert.Equal(source.PairName, destination.PairName);
        Assert.Equal(source.ExchangeName, destination.ExchangeName);
    }

    [Fact]
    public void Mapping_ExchangePriceOperationModel_To_ExchangePriceDto_MapsPrice()
    {
        // Arrange
        var source = new ExchangePriceOperationModel
        {
            Price = 123.45m
        };

        // Act
        var destination = _mapper.Map<ExchangePriceDto>(source);

        // Assert
        Assert.Equal(source.Price, destination.Price);
    }
}

