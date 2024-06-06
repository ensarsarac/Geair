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
    public class GetUserCountQueryResultHandler : IRequestHandler<GetUserCountQueryResult, GetUserCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetUserCountQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetUserCountQueryResult> Handle(GetUserCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.UserCount();
            return new GetUserCountQueryResult { UserCount = value };
        }
    }
}
