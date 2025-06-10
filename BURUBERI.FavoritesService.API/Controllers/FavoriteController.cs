using BURUBERI.FavoritesService.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.FavoritesService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteCommandService _service;

    public FavoriteController(IFavoriteCommandService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddFavorite([FromQuery] int distributorId, [FromQuery] int lotId)
    {
        var id = await _service.AddFavorite(distributorId, lotId);
        return Ok(id);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveFavorite([FromQuery] int distributorId, [FromQuery] int lotId)
    {
        await _service.RemoveFavorite(distributorId, lotId);
        return NoContent();
    }

    [HttpGet("{distributorId}")]
    public async Task<IActionResult> GetFavorites(int distributorId)
    {
        var favorites = await _service.GetFavorites(distributorId);
        return Ok(favorites);
    }
}
