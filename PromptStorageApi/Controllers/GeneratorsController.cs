using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromptStorageApi.Application.Features.Generators.Commands.CreateGenerator;
using PromptStorageApi.Application.Features.Generators.Commands.DeleteGenerator;
using PromptStorageApi.Application.Features.Generators.Queries.GetGeneratorById;
using PromptStorageApi.Application.Features.Generators.Queries.GetGenerators;

namespace PromptStorageApi.Controllers;

[ApiController]
[Route("api/generators")]
public class GeneratorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GeneratorsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => Ok(await _mediator.Send(new GetGeneratorsQuery(), ct));
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        => Ok(await _mediator.Send(new GetGeneratorByIdQuery(id), ct));   

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGeneratorCommand command, CancellationToken ct)
    {
        var created = await _mediator.Send(command, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteGeneratorCommand(id), ct);
        return NoContent();
    }        
}