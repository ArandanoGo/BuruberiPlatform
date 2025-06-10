
using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

namespace BURUBERI.InventoryService.API.Interface.REST.Transform
{
    /// <summary>
    /// Ensamblador para convertir la entidad Reserva a ReservaResource.
    /// </summary>
    public static class ReservaResourceFromEntityAssembler
    {
        public static ReservaResource ToResource(Reserva entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new ReservaResource
            {
                Id = entity.Id,
                IdDistribuidor = entity.IdDistribuidor,
                IdLote = entity.IdLote,
                IdProductor = entity.IdProductor,
                FechaRegistro = entity.FechaRegistro,
                Stock = entity.Stock,
                Estado = entity.Estado
            };
        }
    }
}