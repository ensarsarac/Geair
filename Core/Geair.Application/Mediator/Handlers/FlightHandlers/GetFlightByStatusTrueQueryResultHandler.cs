using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.FlightResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FlightHandlers
{
    public class GetFlightByStatusTrueQueryResultHandler : IRequestHandler<GetFlightByStatusTrueQueryResult, List<GetFlightByStatusTrueQueryResult>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightByStatusTrueQueryResultHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<GetFlightByStatusTrueQueryResult>> Handle(GetFlightByStatusTrueQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _flightRepository.GetAllFlightListByStatusTrueAsync();
            return values.Select(x => new GetFlightByStatusTrueQueryResult
            {
                FlightId = x.FlightId,
                AircraftId = x.AircraftId,
                AircraftModel = x.Aircraft.Model,
                AircraftBaggageWeightPerson = Convert.ToDecimal(x.Aircraft.BaggageWeight) / Convert.ToDecimal(x.Aircraft.Capacity),
                FlightNumber = x.FlightNumber,
                DepartureAirportId = x.DepartureAirportId,
                DepartureAirport = x.DepartureAirport.AirportTitle,
                DepartureAirportCity = x.DepartureAirport.City,
                ArrivalAirportId = x.ArrivalAirportId,
                ArrivalAirport = x.ArrivalAirport.AirportTitle,
                ArrivalAirportCity = x.ArrivalAirport.City,
                DepartureTime = x.DepartureTime,
                ArrivalTime = x.ArrivalTime,
                EconomyPrice = x.EconomyPrice,
                BusinessPrice = x.BusinessPrice,
                FlightType = x.FlightType,
                DateOfReturn=x.DateOfReturn,
                Status = x.Status,
            }).ToList();
        }
    }
}
