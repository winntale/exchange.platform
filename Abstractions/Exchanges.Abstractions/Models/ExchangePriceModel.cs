namespace exchange.platform.clients.abstractions.Models;

public sealed record ExchangePriceModel
{
    public required string Symbol { get; init; }
    public required decimal Price { get; init; }
}