using BURUBERI.FavoritesService.API.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BURUBERI.FavoritesService.API.Infrastructure.Persistence;

public class FavoritesDbContext : DbContext
{
    public FavoritesDbContext(DbContextOptions<FavoritesDbContext> options)
        : base(options) { }

    public DbSet<Favorite> Favorites { get; set; }
}