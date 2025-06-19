using System;

namespace BURUBERI.CommunicationService.API.Domain.Model.Aggregates
{
    public class Mensaje
    {
        public Guid Id { get; set; }                    // ID único del mensaje
        public string RemitenteId { get; set; }         // ID del usuario que envía
        public string RemitenteNombre { get; set; }     // Nombre del usuario que envía
        public string DestinatarioId { get; set; }      // ID del usuario que recibe
        public string DestinatarioNombre { get; set; }  // Nombre del usuario que recibe
        public string Contenido { get; set; }           // Contenido del mensaje
        public DateTime FechaEnvio { get; set; }        // Fecha en la que se envió el mensaje
        
        // Constructor vacío
        public Mensaje()
        {
            RemitenteId = string.Empty;
            RemitenteNombre = string.Empty;
            DestinatarioId = string.Empty;
            DestinatarioNombre = string.Empty;
            Contenido = string.Empty;
            FechaEnvio = DateTime.UtcNow;
        }
    }
}