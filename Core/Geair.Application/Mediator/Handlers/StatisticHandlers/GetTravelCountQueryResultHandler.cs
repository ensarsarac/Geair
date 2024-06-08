using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers;
public class GetTravelCountQueryResultHandler : IRequestHandler<GetTravelCountQueryResult, GetTravelCountQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetTravelCountQueryResultHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }

    public async Task<GetTravelCountQueryResult> Handle(GetTravelCountQueryResult request, CancellationToken cancellationToken)
    {
        var value = await _statisticRepository.TravelCount();
        return new GetTravelCountQueryResult { TravelCount = value };
    }
}
