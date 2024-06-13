using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Geair.Application.Mediator.Results.StatisticResults
{
    public class GetLastTravelDateAndHourQueryResult : IRequest<GetLastTravelDateAndHourQueryResult>
    {
        public string LastTravelDateAndHour { get; set; }
    }
}