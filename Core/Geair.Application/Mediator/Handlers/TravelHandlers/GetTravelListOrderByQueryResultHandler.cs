using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.TravelResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.TravelHandlers
{
    public class GetTravelListOrderByQueryResultHandler : IRequestHandler<GetTravelListOrderByQueryResult, List<GetTravelListOrderByQueryResult>>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IMapper _mapper;

        public GetTravelListOrderByQueryResultHandler(ITravelRepository travelRepository, IMapper mapper)
        {
            _travelRepository = travelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetTravelListOrderByQueryResult>> Handle(GetTravelListOrderByQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _travelRepository.GetTravelListOrderBy();
            var result = _mapper.Map<List<GetTravelListOrderByQueryResult>>(values);
            return result;
        }
    }
}
