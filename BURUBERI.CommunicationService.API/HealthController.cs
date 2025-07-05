using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace;

[ApiController]
[Route("communication")]
public class HealthController : ControllerBase
{
    [HttpGet("status")]
    [HttpGet("/status")]
    public IActionResult Status()
    {
        return Ok("Communication Service is alive");
    }
}