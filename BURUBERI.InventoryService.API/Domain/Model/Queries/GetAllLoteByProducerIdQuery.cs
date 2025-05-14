namespace BURUBERI.InventoryService.API.Domain.Model.Queries;

public class GetAllLoteByProducerIdQuery
{
    public string ProducerId { get; }

    public GetAllLoteByProducerIdQuery(string producerId)
    {
        ProducerId = producerId;
    }
}