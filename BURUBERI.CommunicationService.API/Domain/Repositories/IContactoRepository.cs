using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BURUBERI.CommunicationService.API.Domain.Repositories
{
    public interface IContactoRepository
    {
        Task<IEnumerable<Contacto>> GetAllAsync();
        Task<IEnumerable<Contacto>> GetByDistribuidorIdAsync(string idDistribuidor);
        Task<IEnumerable<Contacto>> GetByProductorIdAsync(string idProductor);
        Task<Contacto> AddAsync(Contacto contacto);
        Task<Contacto?> GetByIdAsync(Guid id);
    }
}