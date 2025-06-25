using System;

namespace BURUBERI.CommunicationService.API.Domain.Model.Queries
{
    public class GetAllContactoByProductorIdQuery
    {
        public string IdProductor { get; }

        public GetAllContactoByProductorIdQuery(string idProductor)
        {
            IdProductor = idProductor ?? throw new ArgumentNullException(nameof(idProductor));
        }
    }
}