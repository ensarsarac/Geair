using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.DestinationCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand>
    {
        private readonly IRepository<Destination> _repository;
        private readonly IMapper _mapper;
        public CreateDestinationCommandHandler(IRepository<Destination> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Destination>(request);
            await _repository.CreateAsync(value);
        }
    }
}
