using Geair.Application.Mediator.Commands.DestinationCommands;
using Geair.Application.Mediator.Queries.DestinationQueries;
using Geair.Application.Mediator.Results.DestinationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class DestinationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DestinationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetDestinationList()
        {
            var values = await _mediator.Send(new GetDestinationListQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDestinationById(int id)
        {
            var values = await _mediator.Send(new GetDestinationByIdQuery(id));
            if(values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest("Bu Id'ye ait bir veri bulunamadı");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDestination(CreateDestinationCommand createDestinationCommand)
        {
            await _mediator.Send(createDestinationCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDestination(UpdateDestinationCommand updateDestinationCommand)
        {
            await _mediator.Send(updateDestinationCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            await _mediator.Send(new RemoveDestinationCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
