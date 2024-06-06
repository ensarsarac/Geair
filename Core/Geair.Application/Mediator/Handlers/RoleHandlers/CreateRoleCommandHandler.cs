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
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IRepository<Role> _repository;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IRepository<Role> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Role>(request));
        }
    }
}
