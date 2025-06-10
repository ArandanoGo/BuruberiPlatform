using BURUBERI.FavoritesService.API.Domain.Model.Entities;
using BURUBERI.FavoritesService.API.Domain.Repositories;

namespace BURUBERI.FavoritesService.API.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly FavoritesDbContext _context;

    public FavoriteRepository(FavoritesDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Favorite favorite)
    {
        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int distributorId, int lotId)
    {
        var favorite = await _context.Favorites
            .FirstOrDefaultAsync(f => f.DistributorId == distributorId && f.LotId == lotId);

        if (favorite != null)
        {
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Favorite>> GetByDistributorAsync(int distributorId)
    {
        return await _context.Favorites
            .Where(f => f.DistributorId == distributorId)
            .ToListAsync();
    }
}