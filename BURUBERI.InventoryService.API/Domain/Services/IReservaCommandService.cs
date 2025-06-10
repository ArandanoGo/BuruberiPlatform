using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Commands;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

namespace BURUBERI.InventoryService.API.Domain.Services;

/// <summary>
/// Service interface for executing commands related to Reserva aggregates.
/// </summary>
public interface IReservaCommandService
{
    /// <summary>
    /// Creates a new Reserva based on the provided command.
    /// </summary>
    /// <param name="command">The command containing reserva creation details.</param>
    /// <returns>The created Reserva aggregate.</returns>
    Task<Reserva> CreateReservaAsync(CreateReservaCommand command);

    /// <summary>
    /// Updates an existing Reserva by ID with the provided data.
    /// </summary>
    /// <param name="id">The ID of the reserva to update.</param>
    /// <param name="resource">The updated reserva data.</param>
    /// <returns>The updated Reserva aggregate.</returns>
    Task<Reserva> UpdateReservaAsync(Guid id, UpdateReservaResource resource);

    /// <summary>
    /// Deletes a Reserva by ID.
    /// </summary>
    /// <param name="id">The ID of the reserva to delete.</param>
    Task DeleteReservaAsync(Guid id);
}