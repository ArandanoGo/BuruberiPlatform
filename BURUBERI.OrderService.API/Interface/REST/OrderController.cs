using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BURUBERI.OrderService.API.Domain.Model.Commands;
using BURUBERI.OrderService.API.Domain.Model.Queries;
using BURUBERI.OrderService.API.Domain.Services;
using BURUBERI.OrderService.API.Interface.REST.Resources;
using BURUBERI.OrderService.API.Interface.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.OrderService.API.Interface.REST
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCommandService _commandService;
        private readonly IOrderQueryService _queryService;

        public OrderController(IOrderCommandService commandService, IOrderQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // POST /api/orders
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderResource resource)
        {
            if (resource == null)
                return BadRequest("Resource cannot be null.");

            var command = CreateOrderCommandFromResourceAssembler.ToCommand(resource);
            var order = await _commandService.CreateOrderAsync(command);
            var response = OrderResourceFromEntityAssembler.ToResource(order);

            return CreatedAtAction(nameof(GetByDistribuidor), new { distribuidorId = response.IdDistribuidor }, response);
        }

        // GET /api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetAll()
        {
            var query = new GetAllOrderQuery(); // assuming you have this query class
            var orders = await _queryService.GetAllOrdersAsync(query);
            var resources = orders.Select(OrderResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        // GET /api/orders/distribuidor/{distribuidorId}
        [HttpGet("distribuidor/{distribuidorId}")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetByDistribuidor(int distribuidorId)
        {
            var query = new GetAllOrderByDistribuidorIdQuery(distribuidorId);
            var orders = await _queryService.GetOrdersByDistribuidorAsync(query);
            var resources = orders.Select(OrderResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        // GET /api/orders/lote/{loteId}
        [HttpGet("lote/{loteId}")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetByLote(string loteId)
        {
            var query = new GetAllOrderByLoteIdQuery(loteId);
            var orders = await _queryService.GetOrdersByLoteAsync(query);
            var resources = orders.Select(OrderResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        // PUT /api/orders/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderResource resource)
        {
            if (resource == null)
                return BadRequest("Resource cannot be null.");

            try
            {
                var updated = await _commandService.UpdateOrderAsync(id, resource);
                var response = OrderResourceFromEntityAssembler.ToResource(updated);
                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE /api/orders/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
