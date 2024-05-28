using Geair.Application.Mediator.Commands.AirportCommands;
using Geair.Application.Mediator.Queries.AirportQueries;
using Geair.Application.Mediator.Results.AirportResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredAdminRole")]
    public class AirportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AirportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAirportList()
        {
            var values = await _mediator.Send(new GetAirportListQueryResult());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirportById(int id)
        {
            var values = await _mediator.Send(new GetAirportByIdQuery(id));
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
        public async Task<IActionResult> CreateAirport(CreateAirportCommand createAirportCommand)
        {
            await _mediator.Send(createAirportCommand);
            return Ok("Kayıt başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAirport(UpdateAirportCommand updateAirportCommand)
        {
            await _mediator.Send(updateAirportCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            await _mediator.Send(new RemoveAirportCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
