using BURUBERI.FavoritesService.API.Domain.Model.Entities;
using BURUBERI.FavoritesService.API.Domain.Repositories;
using BURUBERI.FavoritesService.API.Domain.Services;

namespace BURUBERI.FavoritesService.API.Application.Internal.CommandServices;

public class FavoriteCommandService : IFavoriteCommandService
{
    private readonly IFavoriteRepository _repository;

    public FavoriteCommandService(IFavoriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddFavorite(int distributorId, int lotId)
    {
        var favorite = new Favorite { DistributorId = distributorId, LotId = lotId };
        await _repository.AddAsync(favorite);
        return favorite.Id;
    }

    public async Task RemoveFavorite(int distributorId, int lotId)
    {
        await _repository.RemoveAsync(distributorId, lotId);
    }

    public async Task<List<Favorite>> GetFavorites(int distributorId)
    {
        return await _repository.GetByDistributorAsync(distributorId);
    }
}