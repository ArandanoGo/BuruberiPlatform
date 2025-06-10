using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BURUBERI.InventoryService.API.Infrastructure.Persistence.EFC.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _context.Reservas.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> GetByProductorAsync(string idProductor)
        {
            return await _context.Reservas
                .AsNoTracking()
                .Where(r => r.IdProductor == idProductor)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Reserva>> GetByDistribuidorAsync(string idDistribuidor)
        {
            return await _context.Reservas
                .AsNoTracking()
                .Where(r => r.IdDistribuidor == idDistribuidor)
                .ToListAsync();
        }

        public async Task<Reserva> AddAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<Reserva> UpdateAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task DeleteAsync(Guid id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return;
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task<Reserva?> GetByIdAsync(Guid id)
        {
            return await _context.Reservas.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}