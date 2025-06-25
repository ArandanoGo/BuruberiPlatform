using System;

namespace BURUBERI.CommunicationService.API.Interface.REST.Resources
{
    /// <summary>
    /// Recurso que representa un Contacto retornado por la API.
    /// </summary>
    public class ContactoResource
    {
        public Guid Id { get; set; }                     // ID único del contacto
        public string IdDistribuidor { get; set; }       // ID del distribuidor
        public string IdProductor { get; set; }          // ID del productor
    }
}