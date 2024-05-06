using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.FlightOptionResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FlightOptionHandlers
{
    public class GetFlightOptionListQueryResultHandler : IRequestHandler<GetFlightOptionListQueryResult, List<GetFlightOptionListQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FlightOptions> _repository;

        public GetFlightOptionListQueryResultHandler(IRepository<FlightOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFlightOptionListQueryResult>> Handle(GetFlightOptionListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetFlightOptionListQueryResult>>(values);
            return result;
        }
    }
}
