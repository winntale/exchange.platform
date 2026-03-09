namespace Core.Abstractions.Operations.Price.Queries;

public sealed record GetExchangePriceOperationModel
{
    public required string PairName { get; init; }
    public required string ExchangeName { get; init; }
}