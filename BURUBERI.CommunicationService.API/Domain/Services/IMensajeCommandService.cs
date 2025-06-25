using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Domain.Model.Commands;

namespace BURUBERI.CommunicationService.API.Domain.Services
{
    /// <summary>
    /// Interfaz de servicio para ejecutar comandos relacionados al agregado Mensaje.
    /// </summary>
    public interface IMensajeCommandService
    {
        /// <summary>
        /// Crea un nuevo Mensaje basado en el comando proporcionado.
        /// </summary>
        /// <param name="command">Comando con los datos para crear el mensaje.</param>
        /// <returns>El agregado Mensaje creado.</returns>
        Task<Mensaje> CreateMensajeAsync(CreateMensajeCommand command);
    }
}