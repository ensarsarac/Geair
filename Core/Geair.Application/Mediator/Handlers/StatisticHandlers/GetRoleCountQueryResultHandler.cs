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
    public class GetRoleCountQueryResultHandler : IRequestHandler<GetRoleCountQueryResult, GetRoleCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetRoleCountQueryResultHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetRoleCountQueryResult> Handle(GetRoleCountQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.RoleCount();
            return new GetRoleCountQueryResult { RoleCount = value };
        }
    }
}
