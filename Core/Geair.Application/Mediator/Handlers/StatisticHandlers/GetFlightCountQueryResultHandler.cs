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
    public class GetFlightCountQueryResultHandler : IRequestHandler<GetFlightCountQueryResult, GetFlightCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetFlightCountQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async Task<GetFlightCountQueryResult> Handle(GetFlightCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.FlightCount();
            return new GetFlightCountQueryResult { FlightCount = value };
        }
    }
}
