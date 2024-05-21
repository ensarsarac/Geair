using Geair.Application.Mediator.Commands.CategoryCommands;
using Geair.Application.Mediator.Queries.CategoryQueries;
using Geair.Application.Mediator.Results.CategoryResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredAdminRole")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoryList()
        {
            var values = await _mediator.Send(new GetCategoryQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var values = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (values != null) return Ok(values);
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _mediator.Send(createCategoryCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
