using BURUBERI.InventoryService.API.Domain.Model.Queries;
using BURUBERI.InventoryService.API.Domain.Services;
using BURUBERI.InventoryService.API.Interface.REST.Resources;
using BURUBERI.InventoryService.API.Interface.REST.Transform;
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

            return CreatedAtAction(nameof(GetByProducer), new { producerId = response.ProducerId }, response);
        }

        // GET /api/lotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoteResource>>> GetAll()
        {
            var query = new GetAllLoteQuery();
            var lots = await _queryService.GetAllLotesAsync(query);
            var resources = new List<LoteResource>();
            foreach (var lot in lots)
            {
                resources.Add(LoteResourceFromEntityAssembler.ToResource(lot));
            }
            return Ok(resources);
        }

        // GET /api/lotes/producer/{producerId}
        [HttpGet("producer/{producerId}")]
        public async Task<ActionResult<IEnumerable<LoteResource>>> GetByProducer(string producerId)
        {
            var query = new GetAllLoteByProducerIdQuery(producerId);
            var lots = await _queryService.GetLotesByProducerAsync(query);
            var resources = new List<LoteResource>();
            foreach (var lot in lots)
            {
                resources.Add(LoteResourceFromEntityAssembler.ToResource(lot));
            }
            return Ok(resources);
        }
    }