using Geair.Application.Mediator.Commands.RoleCommands;
using Geair.Application.Mediator.Queries.RoleQueries;
using Geair.Application.Mediator.Results.RoleResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredAdminRole")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleList()
        {
            var values = await _mediator.Send(new GetRoleQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var values = await _mediator.Send(new GetRoleByIdQuery(id));
            if (values != null) return Ok(values);
            else return BadRequest("Bu Id'ye ait bir veri bulunamadı");
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand createRoleCommand)
        {
            await _mediator.Send(createRoleCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand updateRoleCommand)
        {
            await _mediator.Send(updateRoleCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _mediator.Send(new RemoveRoleCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
