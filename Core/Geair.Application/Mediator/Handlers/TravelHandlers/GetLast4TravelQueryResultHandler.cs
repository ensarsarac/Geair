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
    public class GetLast4TravelQueryResultHandler : IRequestHandler<GetLast4TravelQueryResult, List<GetLast4TravelQueryResult>>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IMapper _mapper;

        public GetLast4TravelQueryResultHandler(ITravelRepository travelRepository, IMapper mapper)
        {
            _travelRepository = travelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetLast4TravelQueryResult>> Handle(GetLast4TravelQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _travelRepository.GetLast4TravelListAsync();
            var result = _mapper.Map<List<GetLast4TravelQueryResult>>(values);
            return result;
        }
    }
}
