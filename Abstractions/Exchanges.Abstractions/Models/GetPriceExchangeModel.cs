namespace exchange.platform.clients.abstractions.Models;

public sealed record GetPriceExchangeModel
{
    public required string Symbol { get; init; }
}