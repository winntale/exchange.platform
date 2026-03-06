using Core.Abstractions.Operations.Price.Queries;

namespace Core.Abstractions.Operations.Price;

public interface IGetExchangePriceOperation
{
    Task<Result<ExchangePriceOperationModel>> GetExchangePriceAsync(
        GetExchangePriceOperationModel operationModel,
        CancellationToken ct);
}