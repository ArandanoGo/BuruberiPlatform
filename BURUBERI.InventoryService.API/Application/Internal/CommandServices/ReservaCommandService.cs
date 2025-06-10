
using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Model.Commands;
using BURUBERI.InventoryService.API.Domain.Repositories;
using BURUBERI.InventoryService.API.Domain.Services;
using BURUBERI.InventoryService.API.Interface.REST.Resources;

namespace BURUBERI.InventoryService.API.Application.Internal.CommandServices
{
    public class ReservaCommandService : IReservaCommandService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaCommandService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<Reserva> CreateReservaAsync(CreateReservaCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var reserva = new Reserva
            {
                Id = Guid.NewGuid(),
                IdDistribuidor = command.IdDistribuidor,
                IdLote = command.IdLote,
                IdProductor = command.IdProductor, // se pasa directamente
                FechaRegistro = command.FechaRegistro,
                Stock = command.Stock,
                Estado = command.Estado
            };

            return await _reservaRepository.AddAsync(reserva);
        }

          public async Task<Reserva> UpdateReservaAsync(Guid id, UpdateReservaResource resource)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null)
                throw new KeyNotFoundException("Reserva no encontrada.");

            // Actualizar con los datos del recurso
            reserva.IdDistribuidor = resource.IdDistribuidor;
            reserva.IdLote = resource.IdLote;
            reserva.IdProductor = resource.IdProductor;
            reserva.FechaRegistro = resource.FechaRegistro;
            reserva.Stock = resource.Stock;
            reserva.Estado = resource.Estado;

            return await _reservaRepository.UpdateAsync(reserva);
        }

        public async Task DeleteReservaAsync(Guid id)
        {
            await _reservaRepository.DeleteAsync(id);
        }
    }
}
