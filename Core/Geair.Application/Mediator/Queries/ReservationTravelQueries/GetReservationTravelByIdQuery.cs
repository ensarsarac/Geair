using Geair.Application.Mediator.Results.ReservationTravelResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.ReservationTravelQueries
{
    public class GetReservationTravelByIdQuery:IRequest<GetReservationTravelByIdQueryResult>
    {
        public int Id { get; set; }

        public GetReservationTravelByIdQuery(int id)
        {
            Id = id;
        }
    }
}
