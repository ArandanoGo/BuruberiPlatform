using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BURUBERI.CommunicationService.API.Infrastructure.Persistence.EFC.Repositories
{
    public class MensajeRepository : IMensajeRepository
    {
        private readonly ApplicationDbContext _context;

        public MensajeRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<IEnumerable<Mensaje>> GetAllAsync() =>
            await _context.Mensajes.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Mensaje>> GetByRemitenteIdAsync(string remitenteId) =>
            await _context.Mensajes
                .AsNoTracking()
                .Where(m => m.RemitenteId == remitenteId)
                .ToListAsync();

        public async Task<Mensaje> AddAsync(Mensaje mensaje)
        {
            _context.Mensajes.Add(mensaje);
            await _context.SaveChangesAsync();
            return mensaje;
        }
        
        public async Task<Mensaje?> GetByIdAsync(Guid id) =>
            await _context.Mensajes.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

    }
}