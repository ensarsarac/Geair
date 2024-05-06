using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.FlightOptionQueries;
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
    public class GetFlightOptionByIdQueryResultHandler : IRequestHandler<GetFlightOptionByIdQuery, GetFlightOptionByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FlightOptions> _repository;

        public GetFlightOptionByIdQueryResultHandler(IRepository<FlightOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetFlightOptionByIdQueryResult> Handle(GetFlightOptionByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetFlightOptionByIdQueryResult>(value);
            return result;
        }
    }
}
