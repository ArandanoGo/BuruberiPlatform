namespace BURUBERI.InventoryService.API.Domain.Model.Queries
{
    public class GetAllReservaByProductorIdQuery
    {
        public string IdProductor { get; }

        public GetAllReservaByProductorIdQuery(string idProductor)
        {
            IdProductor = idProductor;
        }
    }
}