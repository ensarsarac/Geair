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
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand>
    {
        private readonly IRepository<Flight> _repository;

        public UpdateFlightCommandHandler(IRepository<Flight> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FlightId);
            value.DepartureAirportId = request.DepartureAirportId;
            value.ArrivalAirportId = request.ArrivalAirportId;
            value.DepartureTime = request.DepartureTime;
            value.ArrivalTime = request.ArrivalTime;
            value.AircraftId = request.AircraftId;
            value.EconomyPrice = request.EconomyPrice;
            value.BusinessPrice= request.BusinessPrice;
            value.DateOfReturn = request.DateOfReturn;
            value.FlightType = request.FlightType;
            await _repository.UpdateAsync(value);
        }
    }
}
