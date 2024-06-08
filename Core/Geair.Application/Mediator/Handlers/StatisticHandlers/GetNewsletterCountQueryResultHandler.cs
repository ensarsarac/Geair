using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers;
public class GetNewsletterCountQueryResultHandler : IRequestHandler<GetNewsletterCountQueryResult, GetNewsletterCountQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetNewsletterCountQueryResultHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    public async Task<GetNewsletterCountQueryResult> Handle(GetNewsletterCountQueryResult request, CancellationToken cancellationToken)
    {
        var value = await _statisticRepository.NewsletterCount();
        return new GetNewsletterCountQueryResult { NewsletterCount = value };
    }
}
