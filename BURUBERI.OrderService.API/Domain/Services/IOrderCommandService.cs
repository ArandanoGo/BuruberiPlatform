using System.Threading.Tasks;
using BURUBERI.OrderService.API.Domain.Model.Aggregates;
using BURUBERI.OrderService.API.Domain.Model.Commands;
using BURUBERI.OrderService.API.Interface.REST.Resources;

namespace BURUBERI.OrderService.API.Domain.Services
{
    /// <summary>
    /// Service interface for executing commands related to Order aggregates.
    /// </summary>
    public interface IOrderCommandService
    {
        /// <summary>
        /// Creates a new Order based on the provided command.
        /// </summary>
        /// <param name="command">The command containing order creation details.</param>
        /// <returns>The created Order aggregate.</returns>
        Task<Order> CreateOrderAsync(CreateOrderCommand command);

        /// <summary>
        /// Updates an existing Order based on the provided resource.
        /// </summary>
        /// <param name="id">The ID of the order to update.</param>
        /// <param name="resource">The resource containing updated order details.</param>
        /// <returns>The updated Order aggregate.</returns>
        Task<Order> UpdateOrderAsync(int id, UpdateOrderResource resource);

        /// <summary>
        /// Deletes an existing Order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order to delete.</param>
        Task DeleteOrderAsync(int id);
    }
}