using AutoMapper;
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
    public class GetFlightQueryResultHandler : IRequestHandler<GetFlightQueryResult, List<GetFlightQueryResult>>
    {
        private readonly IFlightRepository _repository;
        private readonly IMapper _mapper;

        public GetFlightQueryResultHandler(IFlightRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFlightQueryResult>> Handle(GetFlightQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllFlightListAsync();
            return values.Select(x => new GetFlightQueryResult
            {
                FlightId = x.FlightId,
                AircraftId = x.AircraftId,
                AircraftModel = x.Aircraft.Model,
                AircraftBaggageWeightPerson=Convert.ToDecimal(x.Aircraft.BaggageWeight) / Convert.ToDecimal(x.Aircraft.Capacity),
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
        }
    }
}
