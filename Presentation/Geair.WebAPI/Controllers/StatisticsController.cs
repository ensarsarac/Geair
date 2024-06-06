using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetUserCount")]
        public async Task<IActionResult> GetUserCount()
        {
            var value = await _mediator.Send(new GetUserCountQueryResult());
            return Ok(value.UserCount);
        }
        [HttpGet("GetFlightCount")]
        public async Task<IActionResult> GetFlightCount()
        {
            var value = await _mediator.Send(new GetFlightCountQueryResult());
            return Ok(value.FlightCount);
        }
        [HttpGet("GetAirportCount")]
        public async Task<IActionResult> GetAirportCount()
        {
            var value = await _mediator.Send(new GetAirportCountQueryResult());
            return Ok(value.AirportCount);
        }
        [HttpGet("GetAircraftCount")]
        public async Task<IActionResult> GetAircraftCount()
        {
            var value = await _mediator.Send(new GetAircraftCountQueryResult());
            return Ok(value.AircraftCount);
        }
    }
}
