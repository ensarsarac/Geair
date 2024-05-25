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
    public class GetTravelByIdQueryResultHandler : IRequestHandler<GetTravelByIdQuery, GetTravelByIdQueryResult>
    {
        private readonly IRepository<Travel> _repository;
        private readonly IMapper _mapper;

        public GetTravelByIdQueryResultHandler(IRepository<Travel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetTravelByIdQueryResult> Handle(GetTravelByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetTravelByIdQueryResult>(value);
        }
    }
}
