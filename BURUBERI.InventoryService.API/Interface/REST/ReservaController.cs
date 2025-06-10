using BURUBERI.InventoryService.API.Domain.Model.Queries;
using BURUBERI.InventoryService.API.Domain.Services;
using BURUBERI.InventoryService.API.Interface.REST.Resources;
using BURUBERI.InventoryService.API.Interface.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.InventoryService.API.Interface.REST
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaCommandService _commandService;
        private readonly IReservaQueryService _queryService;

        public ReservaController(IReservaCommandService commandService, IReservaQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // POST /api/reservas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservaResource resource)
        {
            if (resource == null)
                return BadRequest("Resource cannot be null.");

            var command = CreateReservaCommandFromResourceAssembler.ToCommand(resource);
            var reserva = await _commandService.CreateReservaAsync(command);
            var response = ReservaResourceFromEntityAssembler.ToResource(reserva);

            return CreatedAtAction(nameof(GetByProducer), new { producerId = response.IdProductor }, response);
        }

        // GET /api/reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaResource>>> GetAll()
        {
            var query = new GetAllReservaQuery();
            var reservas = await _queryService.GetAllReservasAsync(query);
            var resources = reservas.Select(ReservaResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        // GET /api/reservas/producer/{producerId}
        [HttpGet("producer/{producerId}")]
        public async Task<ActionResult<IEnumerable<ReservaResource>>> GetByProducer(string producerId)
        {
            var query = new GetAllReservaByProductorIdQuery(producerId);
            var reservas = await _queryService.GetReservasByProducerAsync(query);
            var resources = reservas.Select(ReservaResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }
        
        // GET /api/reservas/distributor/{distributorId}
        [HttpGet("distributor/{distributorId}")]
        public async Task<ActionResult<IEnumerable<ReservaResource>>> GetByDistributor(string distributorId)
        {
            var query = new GetAllReservaByDistribuidorIdQuery(distributorId);
            var reservas = await _queryService.GetReservasByDistributorAsync(query);
            var resources = reservas.Select(ReservaResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        // PUT /api/reservas/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReservaResource resource)
        {
            if (resource == null)
                return BadRequest("Resource cannot be null.");

            try
            {
                var updated = await _commandService.UpdateReservaAsync(id, resource);
                var response = ReservaResourceFromEntityAssembler.ToResource(updated);
                return Ok(response);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE /api/reservas/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _commandService.DeleteReservaAsync(id);
            return NoContent();
        }
    }
}
