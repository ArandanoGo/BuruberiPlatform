using System;

namespace BURUBERI.InventoryService.API.Domain.Model.Aggregates
{
    public class Lote
    {
        public Guid Id { get; set; }                    // ID único del lote
        public string Autor { get; set; }               // Autor que registra el lote
        public DateTime FechaRegistro { get; set; }     // Fecha en que se registra el lote (UTC)
        public string Hora { get; set; }                // Hora de registro (ej: "14:30")

        // Atributos de fertilización/analítica
        public double MateriaOrganica { get; set; }     // Cantidad de materia orgánica
        public double CloruroPotasio { get; set; }      // Cantidad de cloruro de potasio
        public double Fosfato { get; set; }             // Cantidad de fosfato
        public double SulfatoCalcio { get; set; }       // Cantidad de sulfato de calcio
        public double Urea { get; set; }                // Cantidad de urea
        public double SulfatoMagnesio { get; set; }     // Cantidad de sulfato de magnesio
        public double CorrectoresPH { get; set; }       // Cantidad de correctores de pH

        public string IdProductor { get; set; }         // ID del productor
        public string Tipo { get; set; }                // Tipo de arándano (ej: "Biloxi", "Emerald", etc.)
        public double PesoKg { get; set; }              // Peso total del lote en kilogramos
        public decimal PrecioUnitario { get; set; }     // Precio por kilogramo
        public string Calidad { get; set; }             // Calidad (ej: "A1", "B", "Premium", etc.)
        public string Estado { get; set; }              // Estado del lote ("Disponible", "Reservado", "Vendido", etc.)
        public double Stock { get; set; }               // Stock actual disponible (en kg)

        public DateTime? FechaPedido { get; set; }      // Fecha de pedido (puede ser null)
        public string ImagenUrl { get; set; }           // URL de la imagen

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;       // Fecha de creación en UTC
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;  // Fecha de última actualización en UTC

        // Constructor vacío (opcional, si tu ORM lo necesita)
        public Lote()
        {
            Autor = string.Empty;
            Hora = string.Empty;
            MateriaOrganica = 0;
            CloruroPotasio = 0;
            Fosfato = 0;
            SulfatoCalcio = 0;
            Urea = 0;
            SulfatoMagnesio = 0;
            CorrectoresPH = 0;
            IdProductor = string.Empty;
            Tipo = string.Empty;
            PesoKg = 0;
            PrecioUnitario = 0m;
            Calidad = string.Empty;
            Estado = string.Empty;
            Stock = 0;
            FechaPedido = null;
            ImagenUrl = string.Empty;
        }
    }
}
