using System.Collections.Generic;
using System.Threading.Tasks;
using BURUBERI.OrderService.API.Domain.Model.Aggregates;

namespace BURUBERI.OrderService.API.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetByDistribuidorAsync(int idDistribuidor);
        Task<IEnumerable<Order>> GetByLoteAsync(string idLote);
        Task<Order> AddAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task DeleteAsync(int id);
        Task<Order?> GetByIdAsync(int id);
    }
}