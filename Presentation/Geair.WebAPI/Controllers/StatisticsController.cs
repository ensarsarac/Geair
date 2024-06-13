using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "RequiredModeratorRole")]
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
        [HttpGet("GetBlogCategoriesCount")]
        public async Task<IActionResult> GetBlogCategoriesCount()
        {
            var value = await _mediator.Send(new GetBlogCategoriesCountQueryResult());
            return Ok(value.BlogCategoriesCount);
        }
        [HttpGet("GetRoleCount")]
        public async Task<IActionResult> GetRoleCount()
        {
            var value = await _mediator.Send(new GetRoleCountQueryResult());
            return Ok(value.RoleCount);
        }
        [HttpGet("GetLastFlyDateAndHour")]
        public async Task<IActionResult> GetLastFlyDateAndHour()
        {
            var value = await _mediator.Send(new GetLastFlyDateAndHourQueryResult());
            return Ok(value.LastFlyDateAndHour);
        }
        [HttpGet("GetLastTravelDateAndHour")]
        public async Task<IActionResult> GetLastTravelDateAndHour()
        {
            var value = await _mediator.Send(new GetLastTravelDateAndHourQueryResult());
            return Ok(value.LastTravelDateAndHour);
        }
        [HttpGet("GetMostCategoryName")]
        public async Task<IActionResult> GetMostCategoryName()
        {
            var value = await _mediator.Send(new GetMostCategoryNameQueryResult());
            return Ok(value.MostCategoryName);
        }
        [HttpGet("GetMostRegisterTravel")]
        public async Task<IActionResult> GetMostRegisterTravel()
        {
            var value = await _mediator.Send(new GetMostRegisterTravelQueryResult());
            return Ok(value.MostRegisterTravel);
        }
        [HttpGet("GetMostWriterBlogUser")]
        public async Task<IActionResult> GetMostWriterBlogUser()
        {
            var value = await _mediator.Send(new GetMostWriterBlogUserQueryResult());
            return Ok(value.MostWriterBlogUser);
        }
    }
}
