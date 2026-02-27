using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Shows.Commands.CreateShow;
using PromptStorageApi.Application.Features.Shows.Queries.GetShowDetails;
using PromptStorageApi.Application.Features.Shows.Commands.DeleteShow;
using PromptStorageApi.Application.Features.Shows.Commands.AddPerformance;

namespace PromptStorageApi.Controllers;

[ApiController]
[Route("api/shows")]
public class ShowsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShowsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await _mediator.Send(new GetShowsQuery(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        => Ok(await _mediator.Send(new GetShowByIdQuery(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShowCommand command, CancellationToken ct)
    {
        var showId = await _mediator.Send(command, ct);
        return CreatedAtAction(nameof(GetById), new { id = showId }, showId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteShowCommand(id), ct);
        return NoContent();
    }    

    [HttpPost("{showId:guid}/performances")]
    public async Task<IActionResult> AddPerformance(Guid showId, [FromBody] AddPerformanceCommand body, CancellationToken ct)
    {
        var created = await _mediator.Send(body with { ShowId = showId }, ct);
        return Ok(created);
    }
}