using Geair.Application.Mediator.Commands.AircraftCommands;
using Geair.Application.Mediator.Queries.AircraftQueries;
using Geair.Application.Mediator.Results.AircraftResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredAdminRole")]
    public class AircraftsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AircraftsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAircraftList()
        {
            var values = await _mediator.Send(new GetAircraftQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAircraftById(int id)
        {
            var values = await _mediator.Send(new GetAircraftByIdQuery(id));
            if (values != null) return Ok(values);
            else return BadRequest("Bu Id'ye ait bir veri bulunamadı");
        }
        [HttpPost]
        public async Task<IActionResult> CreateAircraft(CreateAircraftCommand createAircraftCommand)
        {
            await _mediator.Send(createAircraftCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAircraft(UpdateAircraftCommand updateAircraftCommand)
        {
            await _mediator.Send(updateAircraftCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAircraft(int id)
        {
            await _mediator.Send(new RemoveAircraftCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
        
        [HttpGet("GetAircraftAndSeats")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAircraftAndSeats(int id)
        {
            var values = await _mediator.Send(new GetAircraftAndSeatsQuery(id));
            return Ok(values);
        }
    }
}
