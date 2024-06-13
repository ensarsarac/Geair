using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers
{
    public class GetMostRegisterTravelQueryResultHandler : IRequestHandler<GetMostRegisterTravelQueryResult, GetMostRegisterTravelQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetMostRegisterTravelQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async Task<GetMostRegisterTravelQueryResult> Handle(GetMostRegisterTravelQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.MostRegisterTravel();
            return new GetMostRegisterTravelQueryResult { MostRegisterTravel = value };
        }
    }
}