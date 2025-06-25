namespace BURUBERI.OrderService.API.Domain.Model.Queries
{
    /// <summary>
    /// Consulta para obtener todas las órdenes por ID de distribuidor.
    /// </summary>
    public class GetAllOrderByDistribuidorIdQuery
    {
        public int IdDistribuidor { get; }

        public GetAllOrderByDistribuidorIdQuery(int idDistribuidor)
        {
            IdDistribuidor = idDistribuidor;
        }
    }
}