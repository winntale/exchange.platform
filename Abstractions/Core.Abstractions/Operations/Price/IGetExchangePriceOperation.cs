using Core.Abstractions.Operations.Price.Queries;

namespace Core.Abstractions.Operations.Price;

public interface IGetExchangePriceOperation
{
    Task<Result<decimal>> GetPriceAsync(
        GetExchangePriceQuery query,
        CancellationToken ct);
}