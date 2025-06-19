using System;

namespace BURUBERI.CommunicationService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso que representa un Mensaje retornado por la API.
    /// </summary>
    public class MensajeResource
    {
        public Guid Id { get; set; }                  // ID único del mensaje
        public string RemitenteId { get; set; }       // ID del usuario que envía
        public string DestinatarioId { get; set; }    // ID del usuario que recibe
        public string Contenido { get; set; }          // Contenido del mensaje
        
        public string DestinatarioNombre { get; set; } // si quieres, sino eliminar
        public string RemitenteNombre { get; set; }  // si quieres, sino eliminar
        public DateTime FechaEnvio { get; set; }       // Fecha en la que se envió el mensaje
    }
}