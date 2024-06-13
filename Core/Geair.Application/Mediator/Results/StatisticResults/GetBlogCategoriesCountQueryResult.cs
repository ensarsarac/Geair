using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.StatisticResults;
public class GetBlogCategoriesCountQueryResult : IRequest<GetBlogCategoriesCountQueryResult>
{
    public int BlogCategoriesCount { get; set; }
}
