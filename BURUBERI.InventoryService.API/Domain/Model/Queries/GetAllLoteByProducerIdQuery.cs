namespace BURUBERI.InventoryService.API.Domain.Model.Queries;

public class GetAllLoteByProducerIdQuery
{
    public string IdProductor { get; }

    public GetAllLoteByProducerIdQuery(string idProductor)
    {
        IdProductor = idProductor;
    }
}