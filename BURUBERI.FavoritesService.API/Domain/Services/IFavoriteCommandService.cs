using BURUBERI.FavoritesService.API.Domain.Model.Entities;

namespace BURUBERI.FavoritesService.API.Domain.Services;

public interface IFavoriteCommandService
{
    Task<int> AddFavorite(int distributorId, int lotId);
    Task RemoveFavorite(int distributorId, int lotId);
    Task<List<Favorite>> GetFavorites(int distributorId);
}