using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Commands;

namespace BURUBERI.InventoryService.API.Domain.Services;

/// <summary>
/// Service interface for executing commands related to Lot aggregates.
/// </summary>
public interface ILoteCommandService
{
    /// <summary>
    /// Creates a new Lot based on the provided command.
    /// </summary>
    /// <param name="command">The command containing lot creation details.</param>
    /// <returns>The created Lot aggregate.</returns>
    Task<Lot> CreateLoteAsync(CreateLoteCommand command);
}