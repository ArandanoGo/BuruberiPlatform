using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Model.Commands;
using BURUBERI.CommunicationService.API.Domain.Repositories;
using BURUBERI.CommunicationService.API.Domain.Services;

namespace BURUBERI.CommunicationService.API.Application.Internal.CommandServices
{
    public class MensajeCommandService : IMensajeCommandService
    {
        private readonly IMensajeRepository _repository;

        public MensajeCommandService(IMensajeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Mensaje> CreateMensajeAsync(CreateMensajeCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var mensaje = new Mensaje
            {
                Id = Guid.NewGuid(),
                RemitenteId = command.RemitenteId,
                RemitenteNombre = command.RemitenteNombre,
                DestinatarioId = command.DestinatarioId,
                DestinatarioNombre = command.DestinatarioNombre,
                Contenido = command.Contenido,
                FechaEnvio = command.FechaEnvio
            };

            return await _repository.AddAsync(mensaje);
        }
    }
}