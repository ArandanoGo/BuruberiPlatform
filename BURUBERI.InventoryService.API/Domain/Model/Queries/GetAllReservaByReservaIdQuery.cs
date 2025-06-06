namespace BURUBERI.InventoryService.API.Domain.Model.Queries;

public class GetAllReservaByDistribuidorIdQuery
{
    public string IdDistribuidor { get; }

    public GetAllReservaByDistribuidorIdQuery(string idDistribuidor)
    {
        IdDistribuidor = idDistribuidor;
    }
}