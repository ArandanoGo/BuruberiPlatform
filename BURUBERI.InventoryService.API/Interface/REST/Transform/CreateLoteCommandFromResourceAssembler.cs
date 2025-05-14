using BURUBERI.InventoryService.API.Domain.Model.Commands;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

namespace BURUBERI.InventoryService.API.Interface.REST.Transform;

/// <summary>
/// Assembler to convert CreateLoteResource to CreateLoteCommand.
/// </summary>
public static class CreateLoteCommandFromResourceAssembler
{
    public static CreateLoteCommand ToCommand(CreateLoteResource resource)
    {
        return new CreateLoteCommand(
            producerId: resource.ProducerId,
            type: resource.Type,
            weightKg: resource.WeightKg,
            unitPrice: resource.UnitPrice,
            quality: resource.Quality,
            initialStockKg: resource.InitialStockKg,
            lotNumber: resource.LotNumber,
            producedAt: resource.ProducedAt,
            expiresAt: resource.ExpiresAt
        );
    }
}