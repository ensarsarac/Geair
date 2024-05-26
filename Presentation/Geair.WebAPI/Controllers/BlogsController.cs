using Geair.Application.Mediator.Commands.BlogCommands;
using Geair.Application.Mediator.Queries.BlogQueries;
using Geair.Application.Mediator.Results.BannerResults;
using Geair.Application.Mediator.Results.BlogResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredAdminRole")]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetBlogList()
        {
            var values = await _mediator.Send(new GetBlogQueryResult());
            return Ok(values);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQuery(id));
            if(values != null) return Ok(values);
            else return BadRequest("Bu Id'ye ait bir veri bulunamadı");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand createBlogCommand)
        {
            await _mediator.Send(createBlogCommand);
            return Ok("Kayıt başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand updateBlogCommand)
        {
            await _mediator.Send(updateBlogCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }

    }
}
