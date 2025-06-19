using BURUBERI.CommunicationService.API.Domain.Model.Commands;
using BURUBERI.CommunicationService.API.Interface.REST.Resources;
using System;

namespace BURUBERI.CommunicationService.API.Interface.REST.Transform
{
    public static class CreateContactoCommandFromResourceAssembler
    {
        public static CreateContactoCommand ToCommand(CreateContactoResource resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            return new CreateContactoCommand(
                idDistribuidor: resource.IdDistribuidor ?? throw new ArgumentNullException(nameof(resource.IdDistribuidor)),
                idProductor: resource.IdProductor ?? throw new ArgumentNullException(nameof(resource.IdProductor))
            );
        }
    }
}