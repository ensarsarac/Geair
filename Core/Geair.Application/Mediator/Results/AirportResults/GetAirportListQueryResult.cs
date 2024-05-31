using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.AirportResults
{
    public class GetAirportListQueryResult:IRequest<List<GetAirportListQueryResult>>
    {
        public int AirportId { get; set; }
        public string AirportTitle { get; set; }
        public string City { get; set; }
    }
}
