namespace BURUBERI.InventoryService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso para actualizar un Lote existente vía API.
    /// </summary>
    public class UpdateLoteResource
    {
        // Datos de registro (si fuera necesario actualizar)
        public string Autor { get; set; }
        public string Hora { get; set; }

        // Atributos de fertilización/analítica
        public double MateriaOrganica { get; set; }
        public double CloruroPotasio { get; set; }
        public double Fosfato { get; set; }
        public double SulfatoCalcio { get; set; }
        public double Urea { get; set; }
        public double SulfatoMagnesio { get; set; }
        public double CorrectoresPH { get; set; }

        // Datos del lote
        public string IdProductor { get; set; }
        public string Tipo { get; set; }
        public double PesoKg { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Calidad { get; set; }
        public string Estado { get; set; }
        public double Stock { get; set; }

        // Campos opcionales/adicionales
        public DateTime? FechaPedido { get; set; }
        public string ImagenUrl { get; set; }
    }
}