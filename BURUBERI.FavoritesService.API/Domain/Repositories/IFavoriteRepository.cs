using BURUBERI.FavoritesService.API.Domain.Model.Entities;

namespace BURUBERI.FavoritesService.API.Domain.Repositories;

public interface IFavoriteRepository
{
    Task AddAsync(Favorite favorite);
    Task RemoveAsync(int distributorId, int lotId);
    Task<List<Favorite>> GetByDistributorAsync(int distributorId);
}