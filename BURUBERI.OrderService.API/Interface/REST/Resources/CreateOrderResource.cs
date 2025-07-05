using System;

namespace BURUBERI.OrderService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso para crear una nueva Orden vía API.
    /// </summary>
    public class CreateOrderResource
    {
        public int IdDistribuidor { get; set; }
        public string IdLote { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdProductor { get; set; } 
    }
}