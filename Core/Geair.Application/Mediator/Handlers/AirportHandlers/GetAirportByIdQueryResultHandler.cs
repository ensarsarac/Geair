using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.AirportQueries;
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
    public class GetAirportByIdQueryResultHandler : IRequestHandler<GetAirportByIdQuery, GetAirportByIdQueryResult>
    {
        private readonly IRepository<Airport> _repository;
        private readonly IMapper _mapper;

        public GetAirportByIdQueryResultHandler(IRepository<Airport> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAirportByIdQueryResult> Handle(GetAirportByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetAirportByIdQueryResult>(values);
            return result;
        }
    }
}
