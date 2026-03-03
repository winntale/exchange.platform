using Core.Abstractions;
using Core.Abstractions.Operations.Price;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.clients.abstractions.Providers;

namespace exchange.platform.core.Operations;

public class GetExchangePriceOperation(IEnumerable<IExchangePriceProvider> providers)
    : IGetExchangePriceOperation
{
    public async Task<Result<decimal>> GetPriceAsync(GetExchangePriceQuery query, CancellationToken ct)
    {
        var provider = providers.FirstOrDefault(p => p.ExchangeName == query.ExchangeName);

        if (provider is null)
        {
            return 0;
        }
        
        var result = await provider.GetPriceAsync(query.PairName, ct);

        return result;
    }

}