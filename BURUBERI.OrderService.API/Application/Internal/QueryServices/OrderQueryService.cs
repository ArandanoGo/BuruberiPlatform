using BURUBERI.OrderService.API.Domain.Model.Aggregates;
using BURUBERI.OrderService.API.Domain.Model.Queries;
using BURUBERI.OrderService.API.Domain.Repositories;
using BURUBERI.OrderService.API.Domain.Services;

namespace BURUBERI.OrderService.API.Application.Internal.QueryServices
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly IOrderRepository _repository;

        public OrderQueryService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(GetAllOrderQuery query)
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByDistribuidorAsync(GetAllOrderByDistribuidorIdQuery query)
        {
            return await _repository.GetByDistribuidorAsync(query.IdDistribuidor);
        }
        
        public async Task<IEnumerable<Order>> GetOrdersByLoteAsync(GetAllOrderByLoteIdQuery query)
        {
            return await _repository.GetByLoteAsync(query.IdLote);
        }
        
    }
}