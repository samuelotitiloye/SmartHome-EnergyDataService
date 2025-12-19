using MediatR;
using Microsoft.AspNetCore.Mvc;
using EnergyDataService.Application.EnergyReadings.Queries;

namespace EnergyDataService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class EnergyReadingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EnergyReadingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(
            new GetEnergyReadingByIdQuery(id));

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}