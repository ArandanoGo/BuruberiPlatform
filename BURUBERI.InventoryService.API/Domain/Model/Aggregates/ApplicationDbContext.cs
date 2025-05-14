using Microsoft.EntityFrameworkCore;

namespace BURUBERI.InventoryService.API.Domain.Model.Aggregates;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet for the Lot aggregate
    public DbSet<Lot> Lots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Lot entity
        modelBuilder.Entity<Lot>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProducerId).IsRequired();
            entity.Property(e => e.Type).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LotNumber).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Quality).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.WeightKg).IsRequired();
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.Stock).IsRequired();
            entity.Property(e => e.ProducedAt).IsRequired();
            entity.Property(e => e.ExpiresAt).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
        });
    }
}