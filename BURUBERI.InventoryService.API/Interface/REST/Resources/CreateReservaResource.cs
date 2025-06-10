namespace BURUBERI.InventoryService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso para crear una nueva Reserva vía API.
    /// </summary>
    public class CreateReservaResource
    {
        public string IdDistribuidor { get; set; }
        public string IdLote { get; set; }      // Usa string si ese es el tipo que manejas para IdLote
        public string IdProductor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double Stock { get; set; }
        public string Estado { get; set; }
    }
}