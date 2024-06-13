using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Geair.Application.Mediator.Results.StatisticResults
{
    public class GetLastFlyDateAndHourQueryResult : IRequest<GetLastFlyDateAndHourQueryResult>
    {
        public string LastFlyDateAndHour { get; set; }
    }
}