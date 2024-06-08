using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.UserCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.UserHandlers
{
	public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand>
	{
		private readonly IUserRepository _userRepository;

		public UpdateUserRoleCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
		{
			await _userRepository.UpdateUserRole(request.UserId, request.RoleId);
		}
	}
}
