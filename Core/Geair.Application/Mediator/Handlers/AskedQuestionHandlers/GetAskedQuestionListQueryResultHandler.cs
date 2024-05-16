using AutoMapper;
using Geair.Application.Interfaces;
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
    public class GetAskedQuestionListQueryResultHandler : IRequestHandler<GetAskedQuestionListQueryResult, List<GetAskedQuestionListQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AskedQuestion> _repository;

        public GetAskedQuestionListQueryResultHandler(IMapper mapper, IRepository<AskedQuestion> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetAskedQuestionListQueryResult>> Handle(GetAskedQuestionListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetAskedQuestionListQueryResult>>(values.OrderBy(i => i.RowNumber).ToList());
            return result;
        }
    }
}
