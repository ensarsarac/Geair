using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.CategoryResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.CategoryHandlers
{
    public class GetCategoryQueryResultHandler : IRequestHandler<GetCategoryQueryResult, List<GetCategoryQueryResult>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryResultHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQueryResult request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<List<GetCategoryQueryResult>>(await _repository.GetAllListAsync());
            return values;
        }
    }
}
