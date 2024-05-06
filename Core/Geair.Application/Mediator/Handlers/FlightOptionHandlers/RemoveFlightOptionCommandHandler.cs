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
    public class RemoveFlightOptionCommandHandler : IRequestHandler<RemoveFlightOptionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FlightOptions> _repository;

        public RemoveFlightOptionCommandHandler(IRepository<FlightOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(RemoveFlightOptionCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
