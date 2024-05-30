using Geair.Application.Mediator.Results.AircraftResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.AircraftQueries
{
    public class GetAircraftByIdQuery:IRequest<GetAircraftByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAircraftByIdQuery(int id)
        {
            Id = id;
        }
    }
}
