using AutoMapper;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.Models;

namespace exchange.platform.GatewayModelsMappingProfiles;

internal sealed class PriceControllerMappingProfile : Profile
{
    public PriceControllerMappingProfile()
    {
        CreateMap<GetExchangePriceDto, GetExchangePriceOperationModel>();
        CreateMap<ExchangePriceOperationModel, ExchangePriceDto>();
    }
}