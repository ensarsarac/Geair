using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers
{
    public class GetLastTravelDateAndHourQueryResultHandler : IRequestHandler<GetLastTravelDateAndHourQueryResult, GetLastTravelDateAndHourQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetLastTravelDateAndHourQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async Task<GetLastTravelDateAndHourQueryResult> Handle(GetLastTravelDateAndHourQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.LastTravelDateAndHour();
            return new GetLastTravelDateAndHourQueryResult { LastTravelDateAndHour = value };
        }
    }
}