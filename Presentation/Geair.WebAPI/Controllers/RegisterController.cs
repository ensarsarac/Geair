using Geair.Application.Mediator.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RegisterController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateUserCommand createUser)
		{
			var result = await _mediator.Send(createUser);
			return Ok(result);
		}

	}
}
