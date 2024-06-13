using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers
{
    public class GetMostCategoryNameQueryResultHandler : IRequestHandler<GetMostCategoryNameQueryResult, GetMostCategoryNameQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetMostCategoryNameQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async Task<GetMostCategoryNameQueryResult> Handle(GetMostCategoryNameQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.MostCategoryName();
            return new GetMostCategoryNameQueryResult { MostCategoryName = value };
        }
    }
}