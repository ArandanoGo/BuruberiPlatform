using BURUBERI.InventoryService.API.Domain.Model.Aggregates;

namespace BURUBERI.InventoryService.API.Domain.Repositories;

public interface ILoteRepository
{
    Task<IEnumerable<Lote>> GetAllAsync();
    Task<IEnumerable<Lote>> GetByProducerAsync(string idProductor);
    Task<Lote> AddAsync(Lote lote);
    Task<Lote> UpdateAsync(Lote lote);
    Task DeleteAsync(Guid id);
    Task<Lote?> GetByIdAsync(Guid id);
}