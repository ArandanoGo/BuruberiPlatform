namespace BURUBERI.CommunicationService.API.Domain.Model.Queries
{
    public class GetAllMensajeByRemitenteIdQuery
    {
        public string RemitenteId { get; }

        public GetAllMensajeByRemitenteIdQuery(string remitenteId)
        {
            RemitenteId = remitenteId ?? throw new ArgumentNullException(nameof(remitenteId));
        }
    }
}