using Geair.Application.Mediator.Commands.ContactCommands;
using Geair.Application.Mediator.Queries.ContactQueries;
using Geair.Application.Mediator.Results.ContactResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetContactList()
        {
            var values = await _mediator.Send(new GetContactQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var values = await _mediator.Send(new GetContactByIdQuery(id));
            if (values != null) return Ok(values);
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand createContactCommand)
        {
            await _mediator.Send(createContactCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _mediator.Send(new RemoveContactCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
