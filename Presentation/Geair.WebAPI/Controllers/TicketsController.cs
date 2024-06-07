using Geair.Application.Mediator.Commands.TicketCommands;
using Geair.Application.Mediator.Queries.TicketQueries;
using Geair.Application.Mediator.Results.TicketResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTicketList()
        {
            var values = await _mediator.Send(new GetTicketQueryResult());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var values = await _mediator.Send(new GetTicketByIdQuery(id));
            if(values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket(UpdateTicketCommand updateTicketCommand)
        {
            await _mediator.Send(updateTicketCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketCommand createTicketCommand)
        {
            await _mediator.Send(createTicketCommand);
            return Ok("Kayıt başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _mediator.Send(new RemoveTicketCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
