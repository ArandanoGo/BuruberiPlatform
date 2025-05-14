using BURUBERI.InventoryService.API.Domain.Model.Aggregates;

namespace BURUBERI.InventoryService.API.Domain.Repositories;

public interface ILoteRepository
{
    Task<IEnumerable<Lot>> GetAllAsync();
    Task<IEnumerable<Lot>> GetByProducerAsync(string producerId);
    Task<Lot> AddAsync(Lot lote);
    Task<Lot> UpdateAsync(Lot lote);
    Task DeleteAsync(Guid id);
    Task<Lot?> GetByIdAsync(Guid id);
}