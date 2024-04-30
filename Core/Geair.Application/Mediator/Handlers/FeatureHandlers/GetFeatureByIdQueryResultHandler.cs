using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.FeatureQueries;
using Geair.Application.Mediator.Results.FeatureResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryResultHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public GetFeatureByIdQueryResultHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetFeatureByIdQueryResult>(values);
            return result;
        }
    }
}
