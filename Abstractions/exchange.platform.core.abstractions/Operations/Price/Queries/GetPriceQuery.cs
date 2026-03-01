namespace exchange.platform.abstractions.Operations.Queries;

public sealed record GetPriceQuery
{
    public required string PairName { get; init; }
    public required string ExchangeName { get; init; }
}