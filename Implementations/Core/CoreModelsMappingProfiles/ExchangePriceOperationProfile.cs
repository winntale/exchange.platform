using AutoMapper;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.clients.abstractions.Models;

namespace exchange.platform.core.CoreModelsMappingProfiles;

internal sealed class ExchangePriceOperationProfile : Profile
{
    public ExchangePriceOperationProfile()
    {
        CreateMap<GetExchangePriceOperationModel, GetPriceExchangeModel>()
            .ForMember(dest => dest.Symbol,
                opt => opt.MapFrom(
                    src => src.PairName));
    }
}