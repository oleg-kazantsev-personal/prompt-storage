using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace PromptStorageApi.Controllers;

[ApiController]
[Route("api/shows")]
public class ShowsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "ok" });
    }
}