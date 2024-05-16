using Geair.Application.Mediator.Results.NewsletterResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.NewsletterQueries;
public class GetNewsletterByIdQuery : IRequest<GetNewsletterByIdQueryResult>
{
    public int Id { get; set; }

    public GetNewsletterByIdQuery(int id)
    {
        Id = id;
    }
}
