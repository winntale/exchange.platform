using AutoMapper;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.Models;

namespace exchange.platform.GatewayModelsMappingProfiles;

public sealed class PriceControllerMappingProfile : Profile
{
    public PriceControllerMappingProfile()
    {
        CreateMap<PriceDto, GetExchangePriceQuery>();
    }
}