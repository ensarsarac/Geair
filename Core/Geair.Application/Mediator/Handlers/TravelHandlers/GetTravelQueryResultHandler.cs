using AutoMapper;
using Geair.Application.Interfaces;
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
    public class GetTravelQueryResultHandler : IRequestHandler<GetTravelQueryResult, List<GetTravelQueryResult>>
    {
        private readonly IRepository<Travel> _repository;
        private readonly IMapper _mapper;

        public GetTravelQueryResultHandler(IRepository<Travel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTravelQueryResult>> Handle(GetTravelQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            return _mapper.Map<List<GetTravelQueryResult>>(values);
        }
    }
}
