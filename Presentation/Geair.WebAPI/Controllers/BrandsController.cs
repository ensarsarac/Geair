using Geair.Application.Mediator.Commands.BrandCommands;
using Geair.Application.Mediator.Queries.BrandQueries;
using Geair.Application.Mediator.Results.BrandResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBrandList()
        {
            var values = await _mediator.Send(new GetBrandListQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var values = await _mediator.Send(new GetBrandByIdQuery(id));
            if(values != null) return Ok(values);
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand createBrandCommand)
        {
            await _mediator.Send(createBrandCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand updateBrandCommand)
        {
            await _mediator.Send(updateBrandCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _mediator.Send(new RemoveBrandCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
