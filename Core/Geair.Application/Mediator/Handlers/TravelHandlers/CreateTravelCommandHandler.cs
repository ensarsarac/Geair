using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.TravelCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.TravelHandlers
{
    public class CreateTravelCommandHandler : IRequestHandler<CreateTravelCommand>
    {
        private readonly IRepository<Travel> _repository;
        private readonly IMapper _mapper;

        public CreateTravelCommandHandler(IRepository<Travel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateTravelCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Travel>(request));
        }
    }
}
