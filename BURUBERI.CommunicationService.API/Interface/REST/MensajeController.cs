
using BURUBERI.CommunicationService.API.Domain.Model.Queries;
using BURUBERI.CommunicationService.API.Domain.Services;
using BURUBERI.CommunicationService.API.Interface.REST.Resources;
using BURUBERI.CommunicationService.API.Interface.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.CommunicationService.API.Interface.REST
{
    [ApiController]
    [Route("api/mensajes")]
    public class MensajeController : ControllerBase
    {
        private readonly IMensajeCommandService _commandService;
        private readonly IMensajeQueryService _queryService;

        public MensajeController(IMensajeCommandService commandService, IMensajeQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // POST /api/mensajes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMensajeResource resource)
        {
            if (resource == null)
                return BadRequest("Resource cannot be null.");

            var command = CreateMensajeCommandFromResourceAssembler.ToCommand(resource);
            var mensaje = await _commandService.CreateMensajeAsync(command);
            var response = MensajeResourceFromEntityAssembler.ToResource(mensaje);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        // GET /api/mensajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MensajeResource>>> GetAll()
        {
            var mensajes = await _queryService.GetAllMensajesAsync();
            var resources = mensajes.Select(MensajeResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        // GET /api/mensajes/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MensajeResource>> GetById(Guid id)
        {
            var mensaje = await _queryService.GetMensajeByIdAsync(id);
            if (mensaje == null)
                return NotFound();

            var resource = MensajeResourceFromEntityAssembler.ToResource(mensaje);
            return Ok(resource);
        }
        
        // GET /api/mensajes/remitente/{remitenteId}
        [HttpGet("remitente/{remitenteId}")]
        public async Task<ActionResult<IEnumerable<MensajeResource>>> GetByRemitenteId(string remitenteId)
        {
            var query = new GetAllMensajeByRemitenteIdQuery(remitenteId);
            var mensajes = await _queryService.GetMensajesByRemitenteIdAsync(query);
            var resources = mensajes.Select(MensajeResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

    }
}
