using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.AircraftCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AircraftHandlers
{
    public class CreateAircraftCommandHandler : IRequestHandler<CreateAircraftCommand>
    {
        private readonly IRepository<Aircraft> _repository;
        private readonly IMapper _mapper;

        public CreateAircraftCommandHandler(IRepository<Aircraft> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateAircraftCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Aircraft>(request));  
        }
    }
}
