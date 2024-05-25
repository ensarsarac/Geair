using Geair.Application.Mediator.Results.TravelResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.TravelQueries
{
    public class GetTravelByIdQuery:IRequest<GetTravelByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTravelByIdQuery(int id)
        {
            Id = id;
        }
    }
}
