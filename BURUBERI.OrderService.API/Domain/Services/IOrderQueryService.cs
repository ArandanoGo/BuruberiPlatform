using System.Collections.Generic;
using System.Threading.Tasks;
using BURUBERI.OrderService.API.Domain.Model.Aggregates;
using BURUBERI.OrderService.API.Domain.Model.Queries;

namespace BURUBERI.OrderService.API.Domain.Services
{
    /// <summary>
    /// Service interface for querying Order aggregates.
    /// </summary>
    public interface IOrderQueryService
    {
        /// <summary>
        /// Retrieves all Order aggregates.
        /// </summary>
        Task<IEnumerable<Order>> GetAllOrdersAsync(GetAllOrderQuery query);

        /// <summary>
        /// Retrieves Order aggregates for a specific distributor.
        /// </summary>
        Task<IEnumerable<Order>> GetOrdersByDistribuidorAsync(GetAllOrderByDistribuidorIdQuery query);

        /// <summary>
        /// Retrieves Order aggregates for a specific lote.
        /// </summary>
        Task<IEnumerable<Order>> GetOrdersByLoteAsync(GetAllOrderByLoteIdQuery query);
    }
}