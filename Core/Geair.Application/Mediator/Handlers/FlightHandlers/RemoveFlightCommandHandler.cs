using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.FlightCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FlightHandlers
{
    public class RemoveFlightCommandHandler : IRequestHandler<RemoveFlightCommand>
    {
        private readonly IRepository<Flight> _flightRepository;

        public RemoveFlightCommandHandler(IRepository<Flight> flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task Handle(RemoveFlightCommand request, CancellationToken cancellationToken)
        {
            await _flightRepository.DeleteAsync(request.Id);
        }
    }
}
