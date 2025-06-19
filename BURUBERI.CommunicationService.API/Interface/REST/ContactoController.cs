using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BURUBERI.CommunicationService.API.Domain.Model.Queries;
using BURUBERI.CommunicationService.API.Domain.Services;
using BURUBERI.CommunicationService.API.Interface.REST.Resources;
using BURUBERI.CommunicationService.API.Interface.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace BURUBERI.CommunicationService.API.Interface.REST
{
    [ApiController]
    [Route("api/contactos")]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoCommandService _commandService;
        private readonly IContactoQueryService _queryService;

        public ContactoController(IContactoCommandService commandService, IContactoQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // POST /api/contactos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactoResource resource)
        {
            if (resource == null)
                return BadRequest("Resource cannot be null.");

            var command = CreateContactoCommandFromResourceAssembler.ToCommand(resource);
            var contacto = await _commandService.CreateContactoAsync(command);
            var response = ContactoResourceFromEntityAssembler.ToResource(contacto);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        // GET /api/contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactoResource>>> GetAll()
        {
            var contactos = await _queryService.GetAllContactosAsync();
            var resources = contactos.Select(ContactoResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        // GET /api/contactos/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContactoResource>> GetById(Guid id)
        {
            var contacto = await _queryService.GetContactoByIdAsync(id);
            if (contacto == null)
                return NotFound();

            var resource = ContactoResourceFromEntityAssembler.ToResource(contacto);
            return Ok(resource);
        }

        // GET /api/contactos/distribuidor/{idDistribuidor}
        [HttpGet("distribuidor/{idDistribuidor}")]
        public async Task<ActionResult<IEnumerable<ContactoResource>>> GetByDistribuidorId(string idDistribuidor)
        {
            var query = new GetAllContactoByDistribuidorIdQuery(idDistribuidor);
            var contactos = await _queryService.GetContactosByDistribuidorIdAsync(query);
            var resources = contactos.Select(ContactoResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }

        // GET /api/contactos/productor/{idProductor}
        [HttpGet("productor/{idProductor}")]
        public async Task<ActionResult<IEnumerable<ContactoResource>>> GetByProductorId(string idProductor)
        {
            var query = new GetAllContactoByProductorIdQuery(idProductor);
            var contactos = await _queryService.GetContactosByProductorIdAsync(query);
            var resources = contactos.Select(ContactoResourceFromEntityAssembler.ToResource);
            return Ok(resources);
        }
    }
}
