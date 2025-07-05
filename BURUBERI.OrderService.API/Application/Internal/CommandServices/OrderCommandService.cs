using BURUBERI.OrderService.API.Domain.Model.Aggregates;
using BURUBERI.OrderService.API.Domain.Model.Commands;
using BURUBERI.OrderService.API.Domain.Repositories;
using BURUBERI.OrderService.API.Domain.Services;
using BURUBERI.OrderService.API.Interface.REST.Resources;
using BURUBERI.OrderService.API.Messaging;

namespace BURUBERI.OrderService.API.Application.Internal.CommandServices
{
    public class OrderCommandService : IOrderCommandService
    {
        private readonly IOrderRepository _repository;
        private readonly EventBusPublisher _eventBusPublisher;

        public OrderCommandService(IOrderRepository repository, EventBusPublisher eventBusPublisher)
        {
            _repository = repository;
            _eventBusPublisher = eventBusPublisher;
        }

        public async Task<Order> CreateOrderAsync(CreateOrderCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var order = new Order
            {
                IdDistribuidor = command.IdDistribuidor,
                IdLote = command.IdLote,
                Cantidad = command.Cantidad,
                Estado = command.Estado,
                FechaPedido = command.FechaPedido,
                IdProductor = command.IdProductor
            };

            var savedOrder = await _repository.AddAsync(order);

            // Publica evento a RabbitMQ
            _eventBusPublisher.PublishOrderCreated(order.IdDistribuidor, order.IdProductor);

            return savedOrder;
        }

        public async Task<Order> UpdateOrderAsync(int id, UpdateOrderResource resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            var order = await _repository.GetByIdAsync(id);
            if (order == null) throw new KeyNotFoundException("Order no encontrado.");

            order.IdDistribuidor = resource.IdDistribuidor;
            order.IdLote = resource.IdLote;
            order.Cantidad = resource.Cantidad;
            order.Estado = resource.Estado;
            order.FechaPedido = resource.FechaPedido;
            order.FechaActualizacion = DateTime.UtcNow;

            return await _repository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
