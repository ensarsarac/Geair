using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.BrandQueries;
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
    public class GetBrandByIdQueryResultHandler : IRequestHandler<GetBrandByIdQuery, GetBrandByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryResultHandler(IMapper mapper, IRepository<Brand> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetBrandByIdQueryResult>(value);
            return result;
        }
    }
}
