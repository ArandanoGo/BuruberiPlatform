using BURUBERI.CommunicationService.API.Domain.Model.Commands;
using BURUBERI.CommunicationService.API.Interface.REST.Resources;

namespace BURUBERI.CommunicationService.API.Interface.REST.Transform
{
    public static class CreateMensajeCommandFromResourceAssembler
    {
        public static CreateMensajeCommand ToCommand(CreateMensajeResource resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            return new CreateMensajeCommand(
                remitenteId: resource.RemitenteId,
                remitenteNombre: resource.RemitenteNombre ?? "",
                destinatarioId: resource.DestinatarioId,
                destinatarioNombre: resource.DestinatarioNombre ?? "",
                contenido: resource.Contenido
            );
        }
    }
}