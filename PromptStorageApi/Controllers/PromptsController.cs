using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace PromptStorageApi.Controllers;

[ApiController]
[Route("api/prompts")]
public class PromptsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "ok" });
    }
}