using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers
{
    public class GetAirportCountQueryResultHandler : IRequestHandler<GetAirportCountQueryResult, GetAirportCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAirportCountQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAirportCountQueryResult> Handle(GetAirportCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.AirportCount();
            return new GetAirportCountQueryResult { AirportCount = value };
        }
    }
}
