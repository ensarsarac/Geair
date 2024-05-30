using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.AircraftQueries;
using Geair.Application.Mediator.Results.AircraftResults;
using MediatR;

namespace Geair.Application.Mediator.Handlers.AircraftHandlers
{
    public class GetAircraftAndSeatsQueryResultHandler : IRequestHandler<GetAircraftAndSeatsQuery, GetAircraftAndSeatsQueryResult>
    {
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IMapper _mapper;
        public GetAircraftAndSeatsQueryResultHandler(IAircraftRepository aircraftRepository, IMapper mapper)
        {
            _aircraftRepository = aircraftRepository;
            _mapper = mapper;
        }
        public async Task<GetAircraftAndSeatsQueryResult> Handle(GetAircraftAndSeatsQuery request, CancellationToken cancellationToken)
        {
            var value = await _aircraftRepository.GetAircraftAndSeats(request.Id);
            return _mapper.Map<GetAircraftAndSeatsQueryResult>(value);
        }
        // public Task<GetAircraftAndSeatsQueryResult> Handle(GetAircraftAndSeatsQuery request, CancellationToken cancellationToken)
        // {
        //     throw new NotImplementedException();
        // }
    }
}