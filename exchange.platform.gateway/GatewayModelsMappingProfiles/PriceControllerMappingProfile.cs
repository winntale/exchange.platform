using AutoMapper;
using exchange.platform.abstractions.Operations.Queries;
using exchange.platform.Models;

namespace exchange.platform.GatewayModelsMappingProfiles;

public sealed class PriceControllerMappingProfile : Profile
{
    public PriceControllerMappingProfile()
    {
        CreateMap<PriceDto, GetPriceQuery>();
    }
}