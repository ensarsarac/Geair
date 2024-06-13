using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers
{
    public class GetMostWriterBlogUserQueryResultHandler : IRequestHandler<GetMostWriterBlogUserQueryResult, GetMostWriterBlogUserQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetMostWriterBlogUserQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async Task<GetMostWriterBlogUserQueryResult> Handle(GetMostWriterBlogUserQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.MostWriterBlogUser();
            return new GetMostWriterBlogUserQueryResult { MostWriterBlogUser = value };
        }
    }
}