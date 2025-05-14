using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

namespace BURUBERI.InventoryService.API.Interface.REST.Transform;
/// <summary>
/// Assembler to convert Lot entity to LoteResource.
/// </summary>
public static class LoteResourceFromEntityAssembler
{
    public static LoteResource ToResource(Lot entity)
    {
        return new LoteResource
        {
            Id = entity.Id,
            ProducerId = entity.ProducerId,
            Type = entity.Type,
            WeightKg = entity.WeightKg,
            UnitPrice = entity.UnitPrice,
            Quality = entity.Quality,
            Status = entity.Status,
            Stock = entity.Stock,
            LotNumber = entity.LotNumber,
            ProducedAt = entity.ProducedAt,
            ExpiresAt = entity.ExpiresAt,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}