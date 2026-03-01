using exchange.platform.abstractions.Operations.Queries;

namespace exchange.platform.abstractions.Operations.Price;

public interface IPriceOperations
{
    Task<int> Get(
        GetPriceQuery query,
        CancellationToken ct);
}