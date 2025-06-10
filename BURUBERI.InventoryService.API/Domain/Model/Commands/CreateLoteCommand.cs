using System;

namespace BURUBERI.InventoryService.API.Domain.Model.Commands
{
    /// <summary>
    /// Comando para crear un nuevo agregado Lote.
    /// </summary>
    public class CreateLoteCommand
    {
        // Datos de registro
        public string Autor { get; }
        public string Hora { get; }

        // Atributos de fertilización/analítica
        public double MateriaOrganica { get; }
        public double CloruroPotasio { get; }
        public double Fosfato { get; }
        public double SulfatoCalcio { get; }
        public double Urea { get; }
        public double SulfatoMagnesio { get; }
        public double CorrectoresPH { get; }

        // Datos del lote
        public string IdProductor { get; }
        public string Tipo { get; }
        public double PesoKg { get; }
        public decimal PrecioUnitario { get; }
        public string Calidad { get; }
        public string Estado { get; }
        public double Stock { get; }

        // Opcionales adicionales
        public DateTime? FechaPedido { get; }
        public string ImagenUrl { get; }

        public CreateLoteCommand(
            string autor,
            string hora,
            double materiaOrganica,
            double cloruroPotasio,
            double fosfato,
            double sulfatoCalcio,
            double urea,
            double sulfatoMagnesio,
            double correctoresPH,
            string idProductor,
            string tipo,
            double pesoKg,
            decimal precioUnitario,
            string calidad,
            string estado,
            double stock,
            DateTime? fechaPedido,
            string imagenUrl
        )
        {
            Autor = autor ?? throw new ArgumentNullException(nameof(autor));
            Hora = hora ?? throw new ArgumentNullException(nameof(hora));
            MateriaOrganica = materiaOrganica;
            CloruroPotasio = cloruroPotasio;
            Fosfato = fosfato;
            SulfatoCalcio = sulfatoCalcio;
            Urea = urea;
            SulfatoMagnesio = sulfatoMagnesio;
            CorrectoresPH = correctoresPH;

            IdProductor = idProductor ?? throw new ArgumentNullException(nameof(idProductor));
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            PesoKg = pesoKg;
            PrecioUnitario = precioUnitario;
            Calidad = calidad ?? throw new ArgumentNullException(nameof(calidad));
            Estado = estado ?? throw new ArgumentNullException(nameof(estado));
            Stock = stock;

            FechaPedido = fechaPedido;      // Puede ser null si no hay pedido
            ImagenUrl = imagenUrl ?? "";    // Cadena vacía si no se proporciona
        }
    }
}
