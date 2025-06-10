namespace BURUBERI.InventoryService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso que representa un Lote retornado por la API.
    /// </summary>
    public class LoteResource
    {
        public Guid Id { get; set; }                     // ID único del lote
        public string Autor { get; set; }                // Autor que registró el lote
        public DateTime FechaRegistro { get; set; }      // Fecha en que se registró el lote (UTC)
        public string Hora { get; set; }                 // Hora de registro (ej: "14:30")

        // Atributos de fertilización/analítica
        public double MateriaOrganica { get; set; }      // Cantidad de materia orgánica
        public double CloruroPotasio { get; set; }       // Cantidad de cloruro de potasio
        public double Fosfato { get; set; }              // Cantidad de fosfato
        public double SulfatoCalcio { get; set; }        // Cantidad de sulfato de calcio
        public double Urea { get; set; }                 // Cantidad de urea
        public double SulfatoMagnesio { get; set; }      // Cantidad de sulfato de magnesio
        public double CorrectoresPH { get; set; }        // Cantidad de correctores de pH

        public string IdProductor { get; set; }          // ID del productor
        public string Tipo { get; set; }                 // Tipo de arándano
        public double PesoKg { get; set; }               // Peso total del lote en kilogramos
        public decimal PrecioUnitario { get; set; }      // Precio por kilogramo
        public string Calidad { get; set; }              // Calidad (ej: "A1", "B", "Premium", etc.)
        public string Estado { get; set; }               // Estado del lote ("Disponible", "Reservado", "Vendido", etc.)
        public double Stock { get; set; }                // Stock actual disponible (en kg)

        public DateTime? FechaPedido { get; set; }       // Fecha de pedido (puede ser null)
        public string ImagenUrl { get; set; }            // URL de la imagen asociada al lote

        public DateTime FechaCreacion { get; set; }      // Fecha de creación en UTC
        public DateTime FechaActualizacion { get; set; } // Fecha de última actualización en UTC
    }
}
