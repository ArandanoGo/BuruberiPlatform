using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BURUBERI.InventoryService.API.Infrastructure.Persistence.EFC.Repositories;

public class LoteRepository : ILoteRepository
{
    private readonly ApplicationDbContext _context;

    public LoteRepository(ApplicationDbContext context) =>
        _context = context;

    public async Task<IEnumerable<Lot>> GetAllAsync() =>
        await _context.Lots.AsNoTracking().ToListAsync();

    public async Task<IEnumerable<Lot>> GetByProducerAsync(string producerId) =>
        await _context.Lots
            .AsNoTracking()
            .Where(l => l.ProducerId == producerId)
            .ToListAsync();

    public async Task<Lot> AddAsync(Lot lote)
    {
        _context.Lots.Add(lote);
        await _context.SaveChangesAsync();
        return lote;
    }
}