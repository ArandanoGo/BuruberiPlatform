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
    
    public async Task<Lot> UpdateAsync(Lot lote)
    {
        _context.Lots.Update(lote);
        await _context.SaveChangesAsync();
        return lote;
    }

    public async Task DeleteAsync(Guid id)
    {
        var lote = await _context.Lots.FindAsync(id);
        if (lote == null) return;
        _context.Lots.Remove(lote);
        await _context.SaveChangesAsync();
    }
    public async Task<Lot?> GetByIdAsync(Guid id)
    {
        return await _context.Lots.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
    }
    
}