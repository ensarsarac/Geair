using Geair.Application.Mediator.Commands.BrandCommands;
using Geair.Application.Mediator.Commands.ReservationTravelCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ReservationTravelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationTravelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservationTravel(CreateReservationTravelCommand createReservationTravelCommand)
        {
            await _mediator.Send(createReservationTravelCommand);
            return Ok("Kayıt başarıyla eklendi");
        }



    }
}
