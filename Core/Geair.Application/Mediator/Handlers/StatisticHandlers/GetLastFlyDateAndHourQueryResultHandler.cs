using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers
{
    public class GetLastFlyDateAndHourQueryResultHandler : IRequestHandler<GetLastFlyDateAndHourQueryResult, GetLastFlyDateAndHourQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetLastFlyDateAndHourQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async Task<GetLastFlyDateAndHourQueryResult> Handle(GetLastFlyDateAndHourQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.LastFlyDateAndHour();
            return new GetLastFlyDateAndHourQueryResult { LastFlyDateAndHour = value };
        }
    }
}