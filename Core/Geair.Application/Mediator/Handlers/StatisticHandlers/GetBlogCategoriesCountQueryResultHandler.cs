using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.StatisticHandlers;

public class GetBlogCategoriesCountQueryResultHandler : IRequestHandler<GetBlogCategoriesCountQueryResult, GetBlogCategoriesCountQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetBlogCategoriesCountQueryResultHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    public async Task<GetBlogCategoriesCountQueryResult> Handle(GetBlogCategoriesCountQueryResult request, CancellationToken cancellationToken)
    {
        var value = await _statisticRepository.BlogCategoriesCount();
        return new GetBlogCategoriesCountQueryResult { BlogCategoriesCount = value };
    }
}
