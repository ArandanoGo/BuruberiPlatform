using System;

namespace BURUBERI.CommunicationService.API.Domain.Model.Queries
{
    public class GetAllContactoByDistribuidorIdQuery
    {
        public string IdDistribuidor { get; }

        public GetAllContactoByDistribuidorIdQuery(string idDistribuidor)
        {
            IdDistribuidor = idDistribuidor ?? throw new ArgumentNullException(nameof(idDistribuidor));
        }
    }
}