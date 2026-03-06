using AutoMapper;
using Core.Abstractions.Operations.Price.Queries;

namespace exchange.platform.core.CoreModelsMappingProfiles;

public sealed class ExchangePriceOperationProfile : Profile
{
    public ExchangePriceOperationProfile()
    {
        CreateMap<GetExchangePriceOperationModel, ExchangePriceOperationModel>()
            .ForMember(d => d.Price, opt => opt.Ignore());
    }
}