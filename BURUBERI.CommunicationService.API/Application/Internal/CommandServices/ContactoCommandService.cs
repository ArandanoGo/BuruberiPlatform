using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Model.Commands;
using BURUBERI.CommunicationService.API.Domain.Repositories;
using BURUBERI.CommunicationService.API.Domain.Services;
using System;
using System.Threading.Tasks;

namespace BURUBERI.CommunicationService.API.Application.Internal.CommandServices
{
    public class ContactoCommandService : IContactoCommandService
    {
        private readonly IContactoRepository _repository;

        public ContactoCommandService(IContactoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Contacto> CreateContactoAsync(CreateContactoCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var contacto = new Contacto
            {
                Id = Guid.NewGuid(),
                IdDistribuidor = command.IdDistribuidor,
                IdProductor = command.IdProductor
                // No hay fechas que asignar según tu modelo
            };

            return await _repository.AddAsync(contacto);
        }
    }
}