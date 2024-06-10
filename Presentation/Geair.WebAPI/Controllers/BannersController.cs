using Geair.Application.Mediator.Commands.BannerCommands;
using Geair.Application.Mediator.Queries.BannerQueries;
using Geair.Application.Mediator.Results.BannerResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredModeratorRole")]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetBannerList()
        {
            var values = await _mediator.Send(new GetBannerListQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var values = await _mediator.Send(new GetBannerByIdQuery(id));
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
        public async Task<IActionResult> CreateBanner(CreateBannerCommand createBannerCommand)
        {
            await _mediator.Send(createBannerCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand updateBannerCommand)
        {
            await _mediator.Send(updateBannerCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _mediator.Send(new RemoveBannerCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
