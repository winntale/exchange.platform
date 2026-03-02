using exchange.platform.abstractions.Operations.Queries;

namespace exchange.platform.abstractions.Operations.Price;

public interface IGetExchangePriceOperation
{
    Task<decimal> GetPriceAsync(
        GetExchangePriceQuery query,
        CancellationToken ct);
}