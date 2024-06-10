using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.UserCommands;
using Geair.Application.Mediator.Queries.UserQueries;
using Geair.Application.Mediator.Results.UserResults;
using Geair.Domain.Entities;
using Geair.Persistance.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequiredAdminRole")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetUserById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }
        [HttpGet("GetUserAndRole")]
        public async Task<IActionResult> GetUserAndRole(int id)
        {
            var user = await _mediator.Send(new GetUserAndRoleQuery(id));
            return Ok(user);
        }
        [HttpGet("GetUserList")]
        public async Task<IActionResult> GetUserList()
        {
            var user = await _mediator.Send(new GetUserQueryResult());
            return Ok(user);
        }
        [HttpGet("GetUserImageAndName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserImageAndName(int id)
        {
            var user = await _mediator.Send(new GetUserImageAndNameQuery(id));
            return Ok(user);
        }
        [HttpPut("UserEditProfile")]
        [AllowAnonymous]
        public async Task<IActionResult> UserEditProfile([FromForm]UpdateUserCommand updateUserCommand)
        {
            try
            {
                await _mediator.Send(updateUserCommand);
                return Ok("Kullanıcı güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            
        }

        [HttpPut("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommand updateUserRoleCommand)
        {
            await _mediator.Send(updateUserRoleCommand);
            return Ok("Rol güncellendi.");
        }
    }
}
