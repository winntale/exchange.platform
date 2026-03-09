namespace exchange.platform.clients.abstractions.Models;

public sealed record PriceExchangeModel
{
    public required string Symbol { get; init; }
    public required decimal Price { get; init; }
}