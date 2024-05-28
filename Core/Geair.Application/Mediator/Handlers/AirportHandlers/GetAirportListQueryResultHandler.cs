using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.AirportResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AirportHandlers
{
    public class GetAirportListQueryResultHandler : IRequestHandler<GetAirportListQueryResult, List<GetAirportListQueryResult>>
    {
        private readonly IRepository<Airport> _repository;
        private readonly IMapper _mapper;

        public GetAirportListQueryResultHandler(IRepository<Airport> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAirportListQueryResult>> Handle(GetAirportListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetAirportListQueryResult>>(values);
            return result;
        }
    }
}
