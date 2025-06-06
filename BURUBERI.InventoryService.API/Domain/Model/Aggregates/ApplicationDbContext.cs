using Microsoft.EntityFrameworkCore;

namespace BURUBERI.InventoryService.API.Domain.Model.Aggregates
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para el agregado Lote
        public DbSet<Lote> Lots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la entidad Lote
            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Datos de registro
                entity.Property(e => e.Autor)
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(e => e.FechaRegistro)
                      .IsRequired();
                entity.Property(e => e.Hora)
                      .HasMaxLength(10)
                      .IsRequired();

                // Atributos de fertilización/analítica
                entity.Property(e => e.MateriaOrganica)
                      .IsRequired();
                entity.Property(e => e.CloruroPotasio)
                      .IsRequired();
                entity.Property(e => e.Fosfato)
                      .IsRequired();
                entity.Property(e => e.SulfatoCalcio)
                      .IsRequired();
                entity.Property(e => e.Urea)
                      .IsRequired();
                entity.Property(e => e.SulfatoMagnesio)
                      .IsRequired();
                entity.Property(e => e.CorrectoresPH)
                      .IsRequired();

                // Datos principales del lote
                entity.Property(e => e.IdProductor)
                      .HasMaxLength(50)
                      .IsRequired();
                entity.Property(e => e.Tipo)
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(e => e.PesoKg)
                      .IsRequired();
                entity.Property(e => e.PrecioUnitario)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();
                entity.Property(e => e.Calidad)
                      .HasMaxLength(50);
                entity.Property(e => e.Estado)
                      .HasMaxLength(20);
                entity.Property(e => e.Stock)
                      .IsRequired();

                // Campos opcionales/adicionales
                entity.Property(e => e.FechaPedido)
                      .IsRequired(false);
                entity.Property(e => e.ImagenUrl)
                      .HasMaxLength(200)
                      .IsRequired(false);

                // Fechas de auditoría
                entity.Property(e => e.FechaCreacion)
                      .IsRequired();
                entity.Property(e => e.FechaActualizacion)
                      .IsRequired();
            });
        }
    }
}
