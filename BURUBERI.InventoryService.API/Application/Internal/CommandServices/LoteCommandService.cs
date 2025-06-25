using System;
using System.Threading.Tasks;
using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Commands;
using BURUBERI.InventoryService.API.Domain.Repositories;
using BURUBERI.InventoryService.API.Domain.Services;
using BURUBERI.InventoryService.API.Interface.REST.Resources;
using BURUBERI.InventoryService.API.Messaging;
using BURUBERI.InventoryService.API.Messaging.Events;

namespace BURUBERI.InventoryService.API.Application.Internal.CommandServices
{
    public class LoteCommandService : ILoteCommandService
    {
        private readonly ILoteRepository _repository;

        public LoteCommandService(ILoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Lote> CreateLoteAsync(CreateLoteCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var lote = new Lote
            {
                Id = Guid.NewGuid(),
                Autor = command.Autor,
                FechaRegistro = DateTime.UtcNow,
                Hora = command.Hora,

                MateriaOrganica = command.MateriaOrganica,
                CloruroPotasio = command.CloruroPotasio,
                Fosfato = command.Fosfato,
                SulfatoCalcio = command.SulfatoCalcio,
                Urea = command.Urea,
                SulfatoMagnesio = command.SulfatoMagnesio,
                CorrectoresPH = command.CorrectoresPH,

                IdProductor = command.IdProductor,
                Tipo = command.Tipo,
                PesoKg = command.PesoKg,
                PrecioUnitario = command.PrecioUnitario,
                Calidad = command.Calidad,
                Estado = command.Estado,
                Stock = command.Stock,

                FechaPedido = command.FechaPedido,
                ImagenUrl = command.ImagenUrl,

                FechaCreacion = DateTime.UtcNow,
                FechaActualizacion = DateTime.UtcNow
            };

            return await _repository.AddAsync(lote);
        }

        public async Task<Lote> UpdateLoteAsync(Guid id, UpdateLoteResource resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            var lote = await _repository.GetByIdAsync(id);
            if (lote == null) throw new KeyNotFoundException("Lote no encontrado.");

            // Actualización del lote
            lote.Autor = resource.Autor;
            lote.Hora = resource.Hora;
            lote.MateriaOrganica = resource.MateriaOrganica;
            lote.CloruroPotasio = resource.CloruroPotasio;
            lote.Fosfato = resource.Fosfato;
            lote.SulfatoCalcio = resource.SulfatoCalcio;
            lote.Urea = resource.Urea;
            lote.SulfatoMagnesio = resource.SulfatoMagnesio;
            lote.CorrectoresPH = resource.CorrectoresPH;
            lote.IdProductor = resource.IdProductor;
            lote.Tipo = resource.Tipo;
            lote.PesoKg = resource.PesoKg;
            lote.PrecioUnitario = resource.PrecioUnitario;
            lote.Calidad = resource.Calidad;
            lote.Estado = resource.Estado;
            lote.Stock = resource.Stock;
            lote.FechaPedido = resource.FechaPedido;
            lote.ImagenUrl = resource.ImagenUrl;
            lote.FechaActualizacion = DateTime.UtcNow;

            var updatedLote = await _repository.UpdateAsync(lote);

// 👉 Publicar evento a RabbitMQ
            var evento = new StockActualizadoEvent
            {
                LoteId = updatedLote.Id,
                NuevoStock = updatedLote.Stock
            };

            var exchange = "review-requests-exchange";
            var routingKey = "get-reviews-by-lote";

            using var publisher = new EventBusPublisher();
            publisher.Publish(exchange, routingKey, evento);


            return updatedLote;
        }


        public async Task DeleteLoteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
