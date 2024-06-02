using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.FlightQueries;
using Geair.Application.Mediator.Results.FlightResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FlightHandlers
{
    public class GetFlightFilterListQueryResultHandler : IRequestHandler<GetFlightFilterListQuery, List<GetFlightFilterListQueryResult>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightFilterListQueryResultHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<GetFlightFilterListQueryResult>> Handle(GetFlightFilterListQuery request, CancellationToken cancellationToken)
        {
                var values = await _flightRepository.GetAllFlightListByFilterAsync(request.FromWhere, request.ToWhere, request.Departure, request.Arrival);
                var result = values.Select(x => new GetFlightFilterListQueryResult
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
                    Status = x.Status,
                }).ToList();
                return result;
            
           
        }


    }
}
