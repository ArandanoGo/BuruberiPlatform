using System;

namespace BURUBERI.OrderService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso para actualizar una Orden existente vía API.
    /// </summary>
    public class UpdateOrderResource
    {
        public int IdDistribuidor { get; set; }
        public string IdLote { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}