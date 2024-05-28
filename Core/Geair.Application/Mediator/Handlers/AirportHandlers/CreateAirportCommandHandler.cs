using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.AirportCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AirportHandlers
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand>
    {
        private readonly IRepository<Airport> _repository;
        private readonly IMapper _mapper;

        public CreateAirportCommandHandler(IRepository<Airport> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Airport>(request);
            await _repository.CreateAsync(value);
        }
    }
}
