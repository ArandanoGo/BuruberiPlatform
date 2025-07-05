using System;

namespace BURUBERI.OrderService.API.Domain.Model.Commands
{
    /// <summary>
    /// Comando para crear una nueva orden.
    /// </summary>
    public class CreateOrderCommand
    {
        public int IdDistribuidor { get; }         // ID del distribuidor
        public string IdLote { get; }              // ID del lote solicitado
        public int Cantidad { get; }               // Cantidad solicitada
        public string Estado { get; }              // Estado de la orden (ej: "pendiente", "procesado")
        public DateTime FechaPedido { get; }       // Fecha del pedido
   
        
        public int IdProductor { get; set; } // ID del productor asociado al lote

        public CreateOrderCommand(
            int idDistribuidor,
            string idLote,
            int cantidad,
            string estado,
            int idProductor,
            DateTime fechaPedido
        )
        {
            if (string.IsNullOrWhiteSpace(idLote))
                throw new ArgumentNullException(nameof(idLote), "El ID del lote no puede estar vacío.");
            
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentNullException(nameof(estado), "El estado no puede estar vacío.");

            IdDistribuidor = idDistribuidor;
            IdLote = idLote;
            Cantidad = cantidad;
            Estado = estado;
            FechaPedido = fechaPedido;
            IdProductor = idProductor;
        }
    }
}