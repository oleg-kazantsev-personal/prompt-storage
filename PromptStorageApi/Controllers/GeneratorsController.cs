using Microsoft.AspNetCore.Mvc;
using MediatR;

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