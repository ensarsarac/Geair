using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Mediator.Results.AircraftResults;
using MediatR;

namespace Geair.Application.Mediator.Queries.AircraftQueries
{
    public class GetAircraftAndSeatsQuery:IRequest<GetAircraftAndSeatsQueryResult>
    {
        public int Id { get; set; }

        public GetAircraftAndSeatsQuery(int id)
        {
            Id = id;
        }
    }
}