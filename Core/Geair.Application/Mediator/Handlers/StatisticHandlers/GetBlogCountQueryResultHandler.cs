using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers;

public class GetBlogCountQueryResultHandler : IRequestHandler<GetBlogCountQueryResult, GetBlogCountQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetBlogCountQueryResultHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQueryResult request, CancellationToken cancellationToken)
    {
        var value = await _statisticRepository.BlogCount();
        return new GetBlogCountQueryResult { BlogCount = value };
    }
}
