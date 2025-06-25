using Microsoft.AspNetCore.Mvc;

namespace ReviewService.ReviewService.Interfaces;

[ApiController]
[Microsoft.AspNetCore.Components.Route("review")]
public class HealthController : ControllerBase
{

    [HttpGet("/status")]
    public IActionResult Status()
    {
        return Ok("Review Service is alive");
    }
}