using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Queries;

namespace BURUBERI.InventoryService.API.Domain.Services;

/// <summary>
/// Service interface for querying Reserva aggregates.
/// </summary>
public interface IReservaQueryService
{
    /// <summary>
    /// Retrieves all Reserva aggregates.
    /// </summary>
    Task<IEnumerable<Reserva>> GetAllReservasAsync(GetAllReservaQuery query);

    /// <summary>
    /// Retrieves Reserva aggregates for a specific producer.
    /// </summary>
    Task<IEnumerable<Reserva>> GetReservasByProducerAsync(GetAllReservaByProductorIdQuery query);
    
    Task<IEnumerable<Reserva>> GetReservasByDistributorAsync(GetAllReservaByDistribuidorIdQuery query);
    
}