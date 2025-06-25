namespace BURUBERI.CommunicationService.API.Domain.Model.Commands
{
    public class CreateMensajeCommand
    {
        public string RemitenteId { get; }
        public string RemitenteNombre { get; }
        public string DestinatarioId { get; }
        public string DestinatarioNombre { get; }
        public string Contenido { get; }
        public DateTime FechaEnvio { get; }

        public CreateMensajeCommand(
            string remitenteId,
            string remitenteNombre,
            string destinatarioId,
            string destinatarioNombre,
            string contenido)
        {
            RemitenteId = remitenteId ?? throw new ArgumentNullException(nameof(remitenteId));
            RemitenteNombre = remitenteNombre ?? "";
            DestinatarioId = destinatarioId ?? throw new ArgumentNullException(nameof(destinatarioId));
            DestinatarioNombre = destinatarioNombre ?? "";
            Contenido = contenido ?? throw new ArgumentNullException(nameof(contenido));
            FechaEnvio = DateTime.UtcNow; // se asigna aquí mismo
        }
    }
}