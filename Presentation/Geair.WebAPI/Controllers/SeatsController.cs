using Geair.Application.Mediator.Commands.SeatCommands;
using Geair.Application.Mediator.Queries.SeatQueries;
using Geair.Application.Mediator.Results.SeatResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredAdminRole")]
    public class SeatsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeatsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSeatList()
        {
            var values = await _mediator.Send(new GetSeatQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatById(int id)
        {
            var values = await _mediator.Send(new GetSeatByIdQuery(id));
            if(values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeat(CreateSeatCommand createSeatCommand)
        {
            await _mediator.Send(createSeatCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeat(UpdateSeatCommand updateSeatCommand)
        {
            await _mediator.Send(updateSeatCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            await _mediator.Send(new RemoveSeatCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
