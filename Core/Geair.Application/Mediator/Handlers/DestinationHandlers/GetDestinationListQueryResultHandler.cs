using AutoMapper;
using Geair.Application.Interfaces;
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
    public class GetDestinationListQueryResultHandler : IRequestHandler<GetDestinationListQueryResult, List<GetDestinationListQueryResult>>
    {
        private readonly IRepository<Destination> _repository;
        private readonly IMapper _mapper;
        public GetDestinationListQueryResultHandler(IRepository<Destination> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<GetDestinationListQueryResult>> Handle(GetDestinationListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetDestinationListQueryResult>>(values);
            return result;
        }
    }
}
