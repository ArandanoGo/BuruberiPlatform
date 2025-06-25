using BURUBERI.InventoryService.API.Domain.Model.Queries;
using BURUBERI.InventoryService.API.Domain.Services;
using BURUBERI.InventoryService.API.Interface.REST.Resources;
using BURUBERI.InventoryService.API.Interface.REST.Transform;
using BURUBERI.InventoryService.API.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.InventoryService.API.Interface.REST;
[ApiController]
    [Route("api/lotes")]
    public class LotController : ControllerBase
    {
        private readonly ILoteCommandService _commandService;
        private readonly ILoteQueryService _queryService;

        public LotController(ILoteCommandService commandService, ILoteQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // POST /api/lotes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLoteResource resource)
        {
            if (resource == null)
                return BadRequest("Resource cannot be null.");

            var command = CreateLoteCommandFromResourceAssembler.ToCommand(resource);
            var lote = await _commandService.CreateLoteAsync(command);
            var response = LoteResourceFromEntityAssembler.ToResource(lote);

            return CreatedAtAction(nameof(GetByProducer), new { producerId = response.IdProductor }, response);
        }

        // GET /api/lotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoteResource>>> GetAll()
        {
            var query = new GetAllLoteQuery();
            var lots = await _queryService.GetAllLotesAsync(query);
            var resources = lots.Select(LoteResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        [HttpGet("producer/{producerId}")]
        public async Task<ActionResult<IEnumerable<LoteResource>>> GetByProducer(string producerId)
        {
            var query = new GetAllLoteByProducerIdQuery(producerId);
            var lots = await _queryService.GetLotesByProducerAsync(query);
            var resources = lots.Select(LoteResourceFromEntityAssembler.ToResource).ToList();

            if (resources.Any())
            {
                var loteId = resources.First().Id; // Escoge el primer lote de la lista

                // Enviamos mensaje a RabbitMQ
                using var publisher = new EventBusPublisher();
                var message = new ReviewRequestMessage { LoteId = loteId };

                publisher.Publish(
                    MessageBusConstants.ExchangeName,
                    MessageBusConstants.RoutingKeyGetReviewsByLote,
                    message
                );
            }

            return Ok(resources);
        }


        // PUT /api/lotes/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLoteResource resource)
        {
            if (resource == null)
                return BadRequest("Resource cannot be null.");

            try
            {
                var updated = await _commandService.UpdateLoteAsync(id, resource);
                var response = LoteResourceFromEntityAssembler.ToResource(updated);
                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE /api/lotes/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _commandService.DeleteLoteAsync(id);
            return NoContent();
        }
    }