using Geair.Application.Mediator.Results.FlightOptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.FlightOptionQueries
{
    public class GetFlightOptionByIdQuery:IRequest<GetFlightOptionByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFlightOptionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
