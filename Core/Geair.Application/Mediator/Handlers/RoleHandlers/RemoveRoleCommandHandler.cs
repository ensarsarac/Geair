using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.RoleCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.RoleHandlers
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand>
    {
        private readonly IRepository<Role> _repository;

        public RemoveRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
