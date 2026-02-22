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
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "ok" });
    }
}