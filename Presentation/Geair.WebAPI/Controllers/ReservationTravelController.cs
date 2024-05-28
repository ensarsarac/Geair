using Geair.Application.Mediator.Commands.BrandCommands;
using Geair.Application.Mediator.Commands.ReservationTravelCommands;
using Geair.Application.Mediator.Queries.ReservationTravelQueries;
using Geair.Application.Mediator.Results.ReservationTravelResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class ReservationTravelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationTravelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReservationTravel(CreateReservationTravelCommand createReservationTravelCommand)
        {
            await _mediator.Send(createReservationTravelCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllReservationTravel()
        {
            var values = await _mediator.Send(new GetReservationTravelQueryResult());
            return Ok(values);
        }
        [HttpGet("GetReservationTravelById")]
        public async Task<IActionResult> GetReservationTravelById(int id)
        {
            var values = await _mediator.Send(new GetReservationTravelByIdQuery(id));
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReservationTravel(UpdateReservationTravelCommand updateReservationTravelCommand)
        {
             await _mediator.Send(updateReservationTravelCommand);
            return Ok("Kayıt başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveReservationTravel(int id)
        {
            await _mediator.Send(new RemoveReservationTravelCommand(id));
            return Ok("Kayıt başarıyla silindi.");
        }
        [HttpGet("ReservationTravelStatusTrue")]
        public async Task<IActionResult> ReservationTravelStatusTrue(int id)
        {
            await _mediator.Send(new UpdateReservationTravelStatusTrueCommand(id));
            return Ok("Durum güncellendi");
        }
    }
}
