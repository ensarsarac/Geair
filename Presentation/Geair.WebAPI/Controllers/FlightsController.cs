using Geair.Application.Mediator.Commands.FlightCommands;
using Geair.Application.Mediator.Queries.FlightQueries;
using Geair.Application.Mediator.Results.FlightResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "RequiredAdminRole")]
    [ApiController]
    
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightCommand createFlightCommand)
        {
            await _mediator.Send(createFlightCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpGet("GetFlightList")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFlightList()
        {
            var values = await _mediator.Send(new GetFlightQueryResult());
            return Ok(values);
        }
        [HttpGet("GetFlightListByStatusTrue")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFlightListByStatusTrue()
        {
            var values = await _mediator.Send(new GetFlightByStatusTrueQueryResult());
            return Ok(values);
        }
        [HttpGet("GetFlightById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var values = await _mediator.Send(new GetFlightByIdQuery(id));
            return Ok(values);
        }
        [HttpPost("GetFlightByFilter")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFlightByFilter(GetFlightFilterListQuery getFlightFilterListQuery)
        {
            var values = await _mediator.Send(getFlightFilterListQuery);
            if (values != null)
                return Ok(values);
            else
                return BadRequest("Girdiğiniz kriterlerde herhangi bir uçuş bulunamadı.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _mediator.Send(new RemoveFlightCommand(id));
            return Ok("Kayıt silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFlight(UpdateFlightCommand updateFlightCommand)
        {
            await _mediator.Send(updateFlightCommand);
            return Ok("Kayıt güncellendi");
        }
    }
}
