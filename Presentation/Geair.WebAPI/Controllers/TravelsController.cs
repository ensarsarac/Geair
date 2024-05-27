using Geair.Application.Mediator.Commands.TravelCommands;
using Geair.Application.Mediator.Queries.TravelQueries;
using Geair.Application.Mediator.Results.TravelResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredAdminRole")]
    public class TravelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TravelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTravelList()
        {
            var values = await _mediator.Send(new GetTravelQueryResult());
            return Ok(values);
        }
        [HttpGet("GetLast4TravelList")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLast4TravelList()
        {
            var values = await _mediator.Send(new GetLast4TravelQueryResult());
            return Ok(values);
        }
        [HttpGet("GetTravelListOrderBy")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTravelListOrderBy()
        {
            var values = await _mediator.Send(new GetTravelListOrderByQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTravelById(int id)
        {
            var values = await _mediator.Send(new GetTravelByIdQuery(id));
            if (values != null) return Ok(values);
            else return BadRequest("Bu Id'ye ait bir veri bulunamadı");
        }
        [HttpPost]
        public async Task<IActionResult> CreateTravel(CreateTravelCommand createTravelCommand)
        {
            await _mediator.Send(createTravelCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTravel(UpdateTravelCommand updateTravelCommand)
        {
            await _mediator.Send(updateTravelCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTravel(int id)
        {
            await _mediator.Send(new RemoveTravelCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
