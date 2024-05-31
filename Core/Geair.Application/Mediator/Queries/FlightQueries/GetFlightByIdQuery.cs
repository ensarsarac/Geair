using Geair.Application.Mediator.Results.FlightResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.FlightQueries
{
    public class GetFlightByIdQuery:IRequest<GetFlightByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFlightByIdQuery(int id)
        {
            Id = id;
        }
    }
}
