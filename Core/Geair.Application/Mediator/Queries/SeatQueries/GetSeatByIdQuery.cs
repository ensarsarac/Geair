using Geair.Application.Mediator.Results.SeatResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.SeatQueries
{
    public class GetSeatByIdQuery:IRequest<GetSeatByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSeatByIdQuery(int id)
        {
            Id = id;
        }
    }
}
