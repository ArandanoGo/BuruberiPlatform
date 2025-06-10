using BURUBERI.InventoryService.API.Domain.Model.Aggregates;

namespace BURUBERI.InventoryService.API.Domain.Repositories;

public interface IReservaRepository
{
    Task<IEnumerable<Reserva>> GetAllAsync();
    Task<IEnumerable<Reserva>> GetByProductorAsync(string idProductor);
    Task<IEnumerable<Reserva>> GetByDistribuidorAsync(string idDistribuidor);
    Task<Reserva> AddAsync(Reserva reserva);
    Task<Reserva> UpdateAsync(Reserva reserva);
    Task DeleteAsync(Guid id);
    Task<Reserva?> GetByIdAsync(Guid id);
}