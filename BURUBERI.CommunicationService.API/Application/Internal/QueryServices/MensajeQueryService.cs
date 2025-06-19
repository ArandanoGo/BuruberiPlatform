using System.Collections.Generic;
using System.Threading.Tasks;
using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Model.Queries;
using BURUBERI.CommunicationService.API.Domain.Repositories;
using BURUBERI.CommunicationService.API.Domain.Services;

namespace BURUBERI.CommunicationService.API.Application.Internal.QueryServices
{
    public class MensajeQueryService : IMensajeQueryService
    {
        private readonly IMensajeRepository _repository;

        public MensajeQueryService(IMensajeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Mensaje>> GetAllMensajesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Mensaje>> GetMensajesByRemitenteIdAsync(GetAllMensajeByRemitenteIdQuery query)
        {
            return await _repository.GetByRemitenteIdAsync(query.RemitenteId);
        }
        
        public async Task<Mensaje?> GetMensajeByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

    }
}