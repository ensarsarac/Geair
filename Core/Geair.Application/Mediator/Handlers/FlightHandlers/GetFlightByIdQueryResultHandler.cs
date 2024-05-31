using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.FlightQueries;
using Geair.Application.Mediator.Results.FlightResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FlightHandlers
{
    public class GetFlightByIdQueryResultHandler : IRequestHandler<GetFlightByIdQuery, GetFlightByIdQueryResult>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightByIdQueryResultHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<GetFlightByIdQueryResult> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _flightRepository.GetFlightByIdAsync(request.Id);
            return new GetFlightByIdQueryResult
            {
                FlightId = value.FlightId,
                AircraftId = value.AircraftId,
                AircraftModel = value.Aircraft.Model,
                AircraftBaggageWeightPerson = Convert.ToDecimal(value.Aircraft.BaggageWeight) / Convert.ToDecimal(value.Aircraft.Capacity),
                FlightNumber = value.FlightNumber,
                DepartureAirportId = value.DepartureAirportId,
                DepartureAirport = value.DepartureAirport.AirportTitle,
                DepartureAirportCity = value.DepartureAirport.City,
                ArrivalAirportId = value.ArrivalAirportId,
                ArrivalAirport = value.ArrivalAirport.AirportTitle,
                ArrivalAirportCity = value.ArrivalAirport.City,
                DepartureTime = value.DepartureTime,
                ArrivalTime = value.ArrivalTime,
                EconomyPrice = value.EconomyPrice,
                BusinessPrice = value.BusinessPrice,
                Status = value.Status,
            };
        }
    }
}
