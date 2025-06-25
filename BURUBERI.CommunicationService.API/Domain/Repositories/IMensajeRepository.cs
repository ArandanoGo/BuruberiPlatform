using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BURUBERI.CommunicationService.API.Domain.Repositories
{
    public interface IMensajeRepository
    {
        Task<IEnumerable<Mensaje>> GetAllAsync();
        Task<IEnumerable<Mensaje>> GetByRemitenteIdAsync(string remitenteId);
        Task<Mensaje> AddAsync(Mensaje mensaje);
        Task<Mensaje?> GetByIdAsync(Guid id);
    }
}