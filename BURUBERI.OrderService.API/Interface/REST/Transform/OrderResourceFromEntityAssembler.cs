using System;
using BURUBERI.OrderService.API.Domain.Model.Aggregates;
using BURUBERI.OrderService.API.Interface.REST.Resources;

namespace BURUBERI.OrderService.API.Interface.REST.Transform
{
    /// <summary>
    /// Ensamblador para convertir la entidad Order a OrderResource.
    /// </summary>
    public static class OrderResourceFromEntityAssembler
    {
        public static OrderResource ToResource(Order entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new OrderResource
            {
                Id = entity.Id,
                IdDistribuidor = entity.IdDistribuidor,
                IdLote = entity.IdLote,
                Cantidad = entity.Cantidad,
                Estado = entity.Estado,
                FechaPedido = entity.FechaPedido
            };
        }
    }
}