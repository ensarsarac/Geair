using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.AircraftQueries;
using Geair.Application.Mediator.Results.AircraftResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AircraftHandlers
{
    public class GetAircraftByIdQueryResultHandler : IRequestHandler<GetAircraftByIdQuery, GetAircraftByIdQueryResult>
    {
        private readonly IRepository<Aircraft> _repository;
        private readonly IMapper _mapper;

        public GetAircraftByIdQueryResultHandler(IRepository<Aircraft> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetAircraftByIdQueryResult> Handle(GetAircraftByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetAircraftByIdQueryResult>(value);
            return result;
        }
    }
}
