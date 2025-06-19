namespace BURUBERI.CommunicationService.API.Interface.REST.Resources
{
    public class CreateMensajeResource
    {
        public string RemitenteId { get; set; }
        public string RemitenteNombre { get; set; }  // si quieres, sino eliminar
        public string DestinatarioId { get; set; }
        public string DestinatarioNombre { get; set; } // si quieres, sino eliminar
        public string Contenido { get; set; }
    }
}