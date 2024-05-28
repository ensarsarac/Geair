using Geair.Application.Mediator.Results.AirportResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.AirportQueries
{
    public class GetAirportByIdQuery:IRequest<GetAirportByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAirportByIdQuery(int id)
        {
            Id = id;
        }
    }
}
