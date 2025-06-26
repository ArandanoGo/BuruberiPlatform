using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.OrderService.API;

[ApiController]
[Route("iam")]
public class HealthController : ControllerBase
{
    [HttpGet("status")]
    [HttpGet("/status")]
    public IActionResult Status()
    {
        return Ok("IAM Service is alive");
    }
}