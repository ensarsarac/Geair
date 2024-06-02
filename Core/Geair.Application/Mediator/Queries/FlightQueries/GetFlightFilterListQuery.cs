using Geair.Application.Mediator.Results.FlightResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.FlightQueries
{
    public class GetFlightFilterListQuery:IRequest<List<GetFlightFilterListQueryResult>>
    {
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
