using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.AskedQuestionQueries;
using Geair.Application.Mediator.Results.AskedQuestionResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AskedQuestionHandlers
{
    public class GetAskedQuestionByIdQueryResultHandler : IRequestHandler<GetAskedQuestionByIdQuery, GetAskedQuestionByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AskedQuestion> _repository;

        public GetAskedQuestionByIdQueryResultHandler(IMapper mapper, IRepository<AskedQuestion> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<GetAskedQuestionByIdQueryResult> Handle(GetAskedQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetAskedQuestionByIdQueryResult>(value);
            return result;
        }
    }
}
