using System;
using BURUBERI.CommunicationService.API.Domain.Model.Aggregates;
using BURUBERI.CommunicationService.API.Interface.REST.Resources;

namespace BURUBERI.CommunicationService.API.Interface.REST.Transform
{
    /// <summary>
    /// Ensamblador para convertir la entidad Mensaje a MensajeResource.
    /// </summary>
    public static class MensajeResourceFromEntityAssembler
    {
        public static MensajeResource ToResource(Mensaje entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new MensajeResource
            {
                Id = entity.Id,
                RemitenteId = entity.RemitenteId,
                DestinatarioId = entity.DestinatarioId,
                Contenido = entity.Contenido,
                FechaEnvio = entity.FechaEnvio,

                FechaCreacion = entity.FechaCreacion,
                FechaActualizacion = entity.FechaActualizacion
            };
        }
    }
}