using AutoMapper;
using Core.Abstractions.Operations.Price.Queries;

namespace exchange.platform.core.CoreModelsMappingProfiles;

internal sealed class ExchangePriceOperationProfile : Profile
{
    public ExchangePriceOperationProfile()
    {
        CreateMap<GetExchangePriceOperationModel, ExchangePriceOperationModel>();
    }
}