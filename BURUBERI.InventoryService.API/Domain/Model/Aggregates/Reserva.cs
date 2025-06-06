using System;

namespace BURUBERI.InventoryService.API.Domain.Model.Aggregates
{
    public class Reserva
    {
        public Guid Id { get; set; }                     // ID único de la reserva
        public string IdDistribuidor { get; set; }       // ID del distribuidor que realiza la reserva
        public string IdProductor { get; set; }          // ID del productor asociado al lote
        public string IdLote { get; set; }               // ID del lote reservado (como string)

        public DateTime FechaRegistro { get; set; }      // Fecha en que se crea la reserva (UTC)
        public double Stock { get; set; }                // Cantidad reservada (en kg)
        public string Estado { get; set; }               // Estado de la reserva (ej: "Pendiente", "Confirmada", etc.)

        // Constructor vacío (requerido por el ORM)
        public Reserva()
        {
            IdDistribuidor = string.Empty;
            IdProductor = string.Empty;
            IdLote = string.Empty;
            FechaRegistro = DateTime.UtcNow;
            Stock = 0;
            Estado = "Pendiente";
        }
    }
}