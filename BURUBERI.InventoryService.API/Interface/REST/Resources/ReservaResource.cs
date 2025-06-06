namespace BURUBERI.InventoryService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso que representa una Reserva retornada por la API.
    /// </summary>
    public class ReservaResource
    {
        public Guid Id { get; set; }                    // ID único de la reserva
        public string IdDistribuidor { get; set; }      // ID del distribuidor que realiza la reserva
        public string IdProductor { get; set; }         // ID del productor dueño del lote reservado
        public string IdLote { get; set; }               // ID del lote reservado (como string si así definiste)

        public DateTime FechaRegistro { get; set; }     // Fecha en que se creó la reserva (UTC)
        public double Stock { get; set; }                // Cantidad reservada (en kg)
        public string Estado { get; set; }               // Estado de la reserva (ej: "Pendiente", "Confirmada", etc.)
    }
}