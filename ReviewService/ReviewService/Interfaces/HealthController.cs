using Microsoft.AspNetCore.Mvc;

namespace ReviewService.ReviewService.Interfaces;

[ApiController]
[Route("review")]
public class HealthController : ControllerBase
{
    [HttpGet("status")]
    [HttpGet("/status")]
    public IActionResult Status()
    {
        return Ok("review Service is alive");
    }
}