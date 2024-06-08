using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.StatisticResults;
public class GetNewsletterCountQueryResult : IRequest<GetNewsletterCountQueryResult>
{
    public int NewsletterCount { get; set; }
}
