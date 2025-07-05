using System;
using BURUBERI.OrderService.API.Domain.Model.Commands;
using BURUBERI.OrderService.API.Interface.REST.Resources;

namespace BURUBERI.OrderService.API.Interface.REST.Transform
{
    /// <summary>
    /// Ensamblador para convertir CreateOrderResource a CreateOrderCommand.
    /// </summary>
    public static class CreateOrderCommandFromResourceAssembler
    {
        public static CreateOrderCommand ToCommand(CreateOrderResource resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            return new CreateOrderCommand(
                idDistribuidor: resource.IdDistribuidor,
                idLote: resource.IdLote,
                cantidad: resource.Cantidad,
                estado: resource.Estado,
                fechaPedido: resource.FechaPedido,
                idProductor: resource.IdProductor
            );
        }
    }
}