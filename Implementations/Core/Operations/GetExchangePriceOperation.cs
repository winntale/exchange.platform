using AutoMapper;
using Core.Abstractions;
using Core.Abstractions.Operations.Price;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.clients.abstractions.Providers;

namespace exchange.platform.core.Operations;

internal sealed class GetExchangePriceOperation(
    IEnumerable<IExchangePriceProvider> providers,
    IMapper mapper)
    : IGetExchangePriceOperation
{
    public async Task<Result<ExchangePriceOperationModel>> GetExchangePriceAsync(
        GetExchangePriceOperationModel operationModel,
        CancellationToken ct)
    {
        var provider = providers.FirstOrDefault(p =>
            string.Equals(p.ExchangeName, operationModel.ExchangeName, StringComparison.OrdinalIgnoreCase));

        if (provider is null)
        {
            return Error.NotFound($"Exchange '{operationModel.ExchangeName} is not supported");
        }
        
        var price = await provider.GetPriceAsync(operationModel.PairName, ct);

        if (price is null)
        {
            return Error.NotFound(
                $"Error getting price for '{operationModel.PairName}' on '{operationModel.ExchangeName}' exchange");
        }

        var model = new ExchangePriceOperationModel { Price = price.Value };

        return Result<ExchangePriceOperationModel>.Success(model);
    }

}