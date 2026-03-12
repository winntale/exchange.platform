using AutoMapper;
using Core.Abstractions;
using Core.Abstractions.Operations.Price;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.clients.abstractions.Models;
using exchange.platform.clients.abstractions.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace exchange.platform.core.Operations;

internal sealed class GetExchangePriceOperation(
    IServiceProvider provider,
    IMapper mapper)
    : IGetExchangePriceOperation
{
    public async Task<Result<ExchangePriceOperationModel>> GetExchangePriceAsync(
        GetExchangePriceOperationModel operationModel,
        CancellationToken ct)
    {
        var client = provider.GetRequiredKeyedService<IPriceExchangeClient>(operationModel.ExchangeName);

        var exchangeModel = mapper.Map<GetPriceExchangeModel>(operationModel);
        
        var exchangeResult = await client.GetPriceQueryAsync(exchangeModel, ct);

        if (exchangeResult is null)
        {
            return Error.NotFound(
                $"Error getting price for '{operationModel.PairName}' on '{operationModel.ExchangeName}' exchange");
        }

        var model = new ExchangePriceOperationModel { Price = exchangeResult.Price };

        return Result<ExchangePriceOperationModel>.Success(model);
    }

}