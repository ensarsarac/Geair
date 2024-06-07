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
    public class GetTicketCountQueryResultHandler : IRequestHandler<GetTicketCountQueryResult, GetTicketCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetTicketCountQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetTicketCountQueryResult> Handle(GetTicketCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.TicketCount();
            return new GetTicketCountQueryResult { TicketCount = value };
        }
    }
}
