using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.FavoritesService.API.Controllers;


    [ApiController]
    [Route("inventory")]
    public class HealthController : ControllerBase
    {
        [HttpGet("status")]
        [HttpGet("/status")]
        public IActionResult Status()
        {
            return Ok("Inventory Service is alive");
        }
    }
