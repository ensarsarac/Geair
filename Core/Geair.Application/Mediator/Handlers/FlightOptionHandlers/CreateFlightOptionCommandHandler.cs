using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.FlightOptionCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FlightOptionHandlers
{
    public class CreateFlightOptionCommandHandler : IRequestHandler<CreateFlightOptionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FlightOptions> _repository;

        public CreateFlightOptionCommandHandler(IRepository<FlightOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateFlightOptionCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<FlightOptions>(request);
            await _repository.CreateAsync(result);
        }
    }
}
