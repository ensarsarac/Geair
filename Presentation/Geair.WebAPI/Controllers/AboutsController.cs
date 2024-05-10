using Geair.Application.Mediator.Commands.AboutCommands;
using Geair.Application.Mediator.Queries.AboutQueries;
using Geair.Application.Mediator.Results.AboutResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAboutList()
        {
            var values = await _mediator.Send(new GetAboutListQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var values = await _mediator.Send(new GetAboutByIdQuery(id));
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
        public async Task<IActionResult> CreateAbout(CreateAboutCommand createAboutCommand)
        {
            await _mediator.Send(createAboutCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
        {
            await _mediator.Send(updateAboutCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
