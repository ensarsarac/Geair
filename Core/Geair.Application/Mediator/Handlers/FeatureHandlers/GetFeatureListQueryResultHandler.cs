using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.BannerResults;
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
    public class GetFeatureListQueryResultHandler : IRequestHandler<GetFeatureListQueryResult, List<GetFeatureListQueryResult>>
    {

        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public GetFeatureListQueryResultHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFeatureListQueryResult>> Handle(GetFeatureListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetFeatureListQueryResult>>(values);
            return result;
        }
    }
}
