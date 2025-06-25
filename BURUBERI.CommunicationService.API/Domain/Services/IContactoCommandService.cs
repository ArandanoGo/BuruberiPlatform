using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Model.Commands;
using System.Threading.Tasks;

namespace BURUBERI.CommunicationService.API.Domain.Services
{
    /// <summary>
    /// Interfaz de servicio para ejecutar comandos relacionados al agregado Contacto.
    /// </summary>
    public interface IContactoCommandService
    {
        /// <summary>
        /// Crea un nuevo Contacto basado en el comando proporcionado.
        /// </summary>
        /// <param name="command">Comando con los datos para crear el contacto.</param>
        /// <returns>El agregado Contacto creado.</returns>
        Task<Contacto> CreateContactoAsync(CreateContactoCommand command);
    }
}