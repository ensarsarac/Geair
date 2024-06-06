using AutoMapper;
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
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IRepository<Role> _repository;

        public UpdateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.RoleId);
            value.RoleName = request.RoleName;
            await _repository.UpdateAsync(value);
        }
    }
}
