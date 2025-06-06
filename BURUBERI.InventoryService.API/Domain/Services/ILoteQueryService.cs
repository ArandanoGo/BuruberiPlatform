using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Queries;

namespace BURUBERI.InventoryService.API.Domain.Services;

/// <summary>
/// Service interface for querying Lot aggregates.
/// </summary>
public interface ILoteQueryService
{
    /// <summary>
    /// Retrieves all Lot aggregates.
    /// </summary>
    Task<IEnumerable<Lote>> GetAllLotesAsync(GetAllLoteQuery query);

    /// <summary>
    /// Retrieves Lot aggregates for a specific producer.
    /// </summary>
    Task<IEnumerable<Lote>> GetLotesByProducerAsync(GetAllLoteByProducerIdQuery query);
}