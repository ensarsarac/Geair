using Geair.Application.Mediator.Commands.FlightOptionCommands;
using Geair.Application.Mediator.Queries.FlightOptionQueries;
using Geair.Application.Mediator.Results.FlightOptionResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightOptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightOptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetFlightOptionList()
        {
            var values = await _mediator.Send(new GetFlightOptionListQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightOptionById(int id)
        {
            var values = await _mediator.Send(new GetFlightOptionByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFlightOption(CreateFlightOptionCommand createFlightOptionCommand)
        {
            await _mediator.Send(createFlightOptionCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFlightOption(UpdateFlightOptionCommand updateFlightOptionCommand)
        {
            await _mediator.Send(updateFlightOptionCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFlightOption(int id)
        {
            await _mediator.Send(new RemoveFlightOptionCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
