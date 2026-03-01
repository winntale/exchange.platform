using AutoMapper;
using exchange.platform.Models;
using exchange.platform.abstractions.Operations.Price;
using exchange.platform.abstractions.Operations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace exchange.platform.Controllers;

[ApiController]
[Route("api/price")]
public sealed class PriceController(IMapper mapper)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<int>> Get(
        [FromServices] IPriceOperations process,
        [FromQuery] PriceDto requestModel,
        CancellationToken ct)
    {
        var queryModel = mapper.Map<GetPriceQuery>(requestModel);

        var result = await process.Get(queryModel, ct);
        return Ok(result);
    }
}