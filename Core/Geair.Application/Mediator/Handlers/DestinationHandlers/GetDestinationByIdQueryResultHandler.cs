using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.DestinationQueries;
using Geair.Application.Mediator.Results.AboutResults;
using Geair.Application.Mediator.Results.DestinationResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryResultHandler : IRequestHandler<GetDestinationByIdQuery, GetDestinationByIdQueryResult>
    {
        private readonly IRepository<Destination> _repository;
        private readonly IMapper _mapper;
        public GetDestinationByIdQueryResultHandler(IRepository<Destination> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetDestinationByIdQueryResult> Handle(GetDestinationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetDestinationByIdQueryResult>(values);
            return result;
        }
    }
}
