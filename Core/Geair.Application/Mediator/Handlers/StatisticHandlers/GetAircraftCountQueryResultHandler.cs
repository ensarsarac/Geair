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
    public class GetAircraftCountQueryResultHandler : IRequestHandler<GetAircraftCountQueryResult, GetAircraftCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAircraftCountQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAircraftCountQueryResult> Handle(GetAircraftCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.AircraftCount();
            return new GetAircraftCountQueryResult { AircraftCount = value };
        }
    }
}
