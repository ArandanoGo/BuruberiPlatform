using System;

namespace BURUBERI.InventoryService.API.Domain.Model.Commands
{
    public class CreateReservaCommand
    {
        public string IdDistribuidor { get; }
        public string IdProductor { get; }
        public string IdLote { get; }
        public DateTime FechaRegistro { get; }
        public double Stock { get; }
        public string Estado { get; }

        public CreateReservaCommand(
            string idDistribuidor,
            string idProductor,
            string idLote,
            DateTime? fechaRegistro,
            double stock,
            string estado
        )
        {
            IdDistribuidor = idDistribuidor ?? throw new ArgumentNullException(nameof(idDistribuidor));
            IdProductor = idProductor ?? throw new ArgumentNullException(nameof(idProductor));
            IdLote = idLote ?? throw new ArgumentNullException(nameof(idLote));
            FechaRegistro = fechaRegistro ?? DateTime.UtcNow;
            Stock = stock;
            Estado = estado ?? throw new ArgumentNullException(nameof(estado));
        }
    }
}