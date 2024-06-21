using Geair.Application.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.BlogQueries
{
    public class GetBlogByCategoryIdQuery:IRequest<List<GetBlogByCategoryIdQueryResult>>
    {
        public int Id { get; set; }

        public GetBlogByCategoryIdQuery(int id)
        {
            Id = id;
        }
    }
}
