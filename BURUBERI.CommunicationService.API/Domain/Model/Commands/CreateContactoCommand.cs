using System;

namespace BURUBERI.CommunicationService.API.Domain.Model.Commands
{
    public class CreateContactoCommand
    {
        public string IdDistribuidor { get; }
        public string IdProductor { get; }

        public CreateContactoCommand(string idDistribuidor, string idProductor)
        {
            IdDistribuidor = idDistribuidor ?? throw new ArgumentNullException(nameof(idDistribuidor));
            IdProductor = idProductor ?? throw new ArgumentNullException(nameof(idProductor));
        }
    }
}