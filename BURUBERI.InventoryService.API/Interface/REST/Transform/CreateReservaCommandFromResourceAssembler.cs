
using BURUBERI.InventoryService.API.Domain.Model.Commands;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

namespace BURUBERI.InventoryService.API.Interface.REST.Transform
{
    /// <summary>
    /// Ensamblador para convertir CreateReservaResource a CreateReservaCommand.
    /// </summary>
    public static class CreateReservaCommandFromResourceAssembler
    {
        public static CreateReservaCommand ToCommand(CreateReservaResource resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            return new CreateReservaCommand(
                idDistribuidor: resource.IdDistribuidor,
                idLote: resource.IdLote,
                idProductor: resource.IdProductor,
                fechaRegistro: resource.FechaRegistro,
                stock: resource.Stock,
                estado: resource.Estado
            );
        }
    }
}