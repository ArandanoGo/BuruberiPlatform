using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BURUBERI.CommunicationService.API.Infrastructure.Persistence.EFC.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactoRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<IEnumerable<Contacto>> GetAllAsync() =>
            await _context.Contactos
                .AsNoTracking()
                .ToListAsync();

        public async Task<IEnumerable<Contacto>> GetByDistribuidorIdAsync(string idDistribuidor) =>
            await _context.Contactos
                .AsNoTracking()
                .Where(c => c.IdDistribuidor == idDistribuidor)
                .ToListAsync();

        public async Task<IEnumerable<Contacto>> GetByProductorIdAsync(string idProductor) =>
            await _context.Contactos
                .AsNoTracking()
                .Where(c => c.IdProductor == idProductor)
                .ToListAsync();

        public async Task<Contacto> AddAsync(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            return contacto;
        }

        public async Task<Contacto?> GetByIdAsync(Guid id) =>
            await _context.Contactos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}