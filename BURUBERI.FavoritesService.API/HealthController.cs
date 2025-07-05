using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.FavoritesService.API;

[ApiController]
[Route("favorites")]
public class HealthController : ControllerBase
{
    [HttpGet("status")]
    [HttpGet("/status")]
    public IActionResult Status()
    {
        return Ok("Favorites Service is alive");
    }
}