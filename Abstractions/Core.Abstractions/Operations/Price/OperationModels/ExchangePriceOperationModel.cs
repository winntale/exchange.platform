namespace Core.Abstractions.Operations.Price.Queries;

public sealed record ExchangePriceOperationModel
{
    public required decimal Price { get; init; }
}