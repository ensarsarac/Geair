using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.BrandResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.BrandHandlers
{
    public class GetBrandListQueryResultHandler : IRequestHandler<GetBrandListQueryResult, List<GetBrandListQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Brand> _repository;

        public GetBrandListQueryResultHandler(IMapper mapper, IRepository<Brand> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetBrandListQueryResult>> Handle(GetBrandListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetBrandListQueryResult>>(values);
            return result;
        }
    }
}
