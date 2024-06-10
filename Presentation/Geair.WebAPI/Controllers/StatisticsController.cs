using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredModeratorRole")]
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
        [HttpGet("GetTicketCount")]
        public async Task<IActionResult> GetTicketCount()
        {
            var value = await _mediator.Send(new GetTicketCountQueryResult());
            return Ok(value.TicketCount);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQueryResult());
            return Ok(value.BlogCount);
        }
        [HttpGet("GetTravelCount")]
        public async Task<IActionResult> GetTravelCount()
        {
            var value = await _mediator.Send(new GetTravelCountQueryResult());
            return Ok(value.TravelCount);
        }
        [HttpGet("GetNewsletterCount")]
        public async Task<IActionResult> GetNewsletterCount()
        {
            var value = await _mediator.Send(new GetNewsletterCountQueryResult());
            return Ok(value.NewsletterCount);
        }
    }
}
