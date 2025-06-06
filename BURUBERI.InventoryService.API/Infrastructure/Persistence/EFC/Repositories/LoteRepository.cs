using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BURUBERI.InventoryService.API.Infrastructure.Persistence.EFC.Repositories;

public class LoteRepository : ILoteRepository
{
    private readonly ApplicationDbContext _context;

    public LoteRepository(ApplicationDbContext context) =>
        _context = context;

    public async Task<IEnumerable<Lote>> GetAllAsync() =>
        await _context.Lots.AsNoTracking().ToListAsync();

    public async Task<IEnumerable<Lote>> GetByProducerAsync(string idProductor) =>
        await _context.Lots
            .AsNoTracking()
            .Where(l => l.IdProductor == idProductor)
            .ToListAsync();

    public async Task<Lote> AddAsync(Lote lote)
    {
        _context.Lots.Add(lote);
        await _context.SaveChangesAsync();
        return lote;
    }
    
    public async Task<Lote> UpdateAsync(Lote lote)
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
    public async Task<Lote?> GetByIdAsync(Guid id)
    {
        return await _context.Lots.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
    }
    
}