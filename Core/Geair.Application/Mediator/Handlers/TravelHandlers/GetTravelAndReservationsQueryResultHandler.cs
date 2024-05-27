using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.TravelQueries;
using Geair.Application.Mediator.Results.TravelResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.TravelHandlers
{
    public class GetTravelAndReservationsQueryResultHandler : IRequestHandler<GetTravelAndReservationsQuery, GetTravelAndReservationsQueryResult>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IMapper _mapper;

        public GetTravelAndReservationsQueryResultHandler(ITravelRepository travelRepository, IMapper mapper)
        {
            _travelRepository = travelRepository;
            _mapper = mapper;
        }
        public async Task<GetTravelAndReservationsQueryResult> Handle(GetTravelAndReservationsQuery request, CancellationToken cancellationToken)
        {
            var value = await _travelRepository.GetTravelAndReservations(request.Id);
            return _mapper.Map<GetTravelAndReservationsQueryResult>(value);
        }
    }
}
