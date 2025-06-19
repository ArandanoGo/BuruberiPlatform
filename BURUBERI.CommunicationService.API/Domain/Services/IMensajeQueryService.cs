using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BURUBERI.CommunicationService.API.Domain.Services
{
    /// <summary>
    /// Service interface for querying Mensaje aggregates.
    /// </summary>
    public interface IMensajeQueryService
    {
        /// <summary>
        /// Retrieves all Mensaje aggregates.
        /// </summary>
        Task<IEnumerable<Mensaje>> GetAllMensajesAsync();

        /// <summary>
        /// Retrieves Mensajes by RemitenteId.
        /// </summary>
        Task<IEnumerable<Mensaje>> GetMensajesByRemitenteIdAsync(GetAllMensajeByRemitenteIdQuery query);
        Task<Mensaje?> GetMensajeByIdAsync(Guid id);

        
    }
}