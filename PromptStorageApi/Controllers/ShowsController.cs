using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Shows.Commands.CreateShow;
using PromptStorageApi.Application.Features.Shows.Queries.GetShowDetails;

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
}