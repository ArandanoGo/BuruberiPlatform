using System;
using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Interface.REST.Resources;

namespace BURUBERI.CommunicationService.API.Interface.REST.Transform
{
    /// <summary>
    /// Ensamblador para convertir la entidad Contacto a ContactoResource.
    /// </summary>
    public static class ContactoResourceFromEntityAssembler
    {
        public static ContactoResource ToResource(Contacto entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new ContactoResource
            {
                Id = entity.Id,
                IdDistribuidor = entity.IdDistribuidor,
                IdProductor = entity.IdProductor
            };
        }
    }
}