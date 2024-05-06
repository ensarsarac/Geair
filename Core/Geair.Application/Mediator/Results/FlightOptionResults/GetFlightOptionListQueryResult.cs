using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.FlightOptionResults
{
    public class GetFlightOptionListQueryResult:IRequest<List<GetFlightOptionListQueryResult>>
    {
        public int FlightOptionsId { get; set; }
        public string Title { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Icon { get; set; }
    }
}
