using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Model.Queries;
using BURUBERI.CommunicationService.API.Domain.Repositories;
using BURUBERI.CommunicationService.API.Domain.Services;

namespace BURUBERI.CommunicationService.API.Application.Internal.QueryServices
{
    public class ContactoQueryService : IContactoQueryService
    {
        private readonly IContactoRepository _repository;

        public ContactoQueryService(IContactoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Contacto>> GetAllContactosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Contacto>> GetContactosByDistribuidorIdAsync(GetAllContactoByDistribuidorIdQuery query)
        {
            return await _repository.GetByDistribuidorIdAsync(query.IdDistribuidor);
        }

        public async Task<IEnumerable<Contacto>> GetContactosByProductorIdAsync(GetAllContactoByProductorIdQuery query)
        {
            return await _repository.GetByProductorIdAsync(query.IdProductor);
        }

        public async Task<Contacto?> GetContactoByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}