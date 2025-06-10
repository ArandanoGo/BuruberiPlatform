using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using ReviewService.ReviewService.Domain.Model.Aggregates;
using ReviewService.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace ReviewService.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Review>().HasKey(f => f.Id);
        builder.Entity<Review>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(f => f.LoteId).IsRequired();
        builder.Entity<Review>().Property(f => f.Puntuacion).IsRequired().HasMaxLength(10);
        builder.UseSnakeCaseNamingConvention();
    }
}