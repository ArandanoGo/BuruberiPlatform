using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Model.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BURUBERI.CommunicationService.API.Domain.Services
{
    /// <summary>
    /// Interfaz de servicio para consultar agregados Contacto.
    /// </summary>
    public interface IContactoQueryService
    {
        /// <summary>
        /// Recupera todos los agregados Contacto.
        /// </summary>
        Task<IEnumerable<Contacto>> GetAllContactosAsync();

        /// <summary>
        /// Recupera contactos por IdDistribuidor.
        /// </summary>
        Task<IEnumerable<Contacto>> GetContactosByDistribuidorIdAsync(GetAllContactoByDistribuidorIdQuery query);

        /// <summary>
        /// Recupera contactos por IdProductor.
        /// </summary>
        Task<IEnumerable<Contacto>> GetContactosByProductorIdAsync(GetAllContactoByProductorIdQuery query);

        /// <summary>
        /// Recupera un contacto por su Id.
        /// </summary>
        Task<Contacto?> GetContactoByIdAsync(Guid id);
    }
}