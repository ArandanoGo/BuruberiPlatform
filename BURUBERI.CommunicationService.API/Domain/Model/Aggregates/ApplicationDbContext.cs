using Microsoft.EntityFrameworkCore;

namespace BURUBERI.CommunicationService.API.Domain.Model.Aggregates
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para el agregado Lote
        
        public DbSet<Mensaje> Mensajes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la entidad Lote
          
        }
    }
}
