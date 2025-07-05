using System;

namespace BURUBERI.OrderService.API.Domain.Model.Aggregates
{
    public class Order
    {
        public int Id { get; set; }                     // ID único de la orden
        public int IdDistribuidor { get; set; }         // ID del distribuidor que realiza el pedido
        public string IdLote { get; set; }              // ID del lote solicitado
        public int Cantidad { get; set; }               // Cantidad solicitada (en kg, unidades, etc.)
        public string Estado { get; set; }              // Estado de la orden ("pendiente", "procesado", etc.)
        
        public int IdProductor { get; set; }         // ID del productor asociado al lote
        public DateTime FechaPedido { get; set; }       // Fecha del pedido (UTC)

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;        // Fecha de creación en UTC
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;   // Fecha de última actualización en UTC

        // Constructor vacío
        public Order()
        {
            IdDistribuidor = 0;
            IdLote = string.Empty;
            Cantidad = 0;
            Estado = string.Empty;
            FechaPedido = DateTime.UtcNow;
        }
    }
}