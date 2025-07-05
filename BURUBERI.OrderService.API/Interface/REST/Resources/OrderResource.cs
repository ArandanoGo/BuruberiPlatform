using System;

namespace BURUBERI.OrderService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso que representa una Orden retornada por la API.
    /// </summary>
    public class OrderResource
    {
        public int Id { get; set; }                      // ID único de la orden
        public int IdDistribuidor { get; set; }          // ID del distribuidor
        public string IdLote { get; set; }                // ID del lote
        public int Cantidad { get; set; }                 // Cantidad solicitada
        public string Estado { get; set; }                // Estado de la orden (ej: "pendiente", "completado")
        public DateTime FechaPedido { get; set; }         // Fecha del pedido (UTC)
        public int IdProductor { get; set; }              // ID del productor asociado al lote
    }
}