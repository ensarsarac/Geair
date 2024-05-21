using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.CategoryQueries;
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
    public class GetCategoryByIdQueryResultHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryResultHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<GetCategoryByIdQueryResult>(await _repository.GetByIdAsync(request.Id));
            return values;
        }
    }
}
