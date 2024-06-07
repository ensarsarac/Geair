using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Mediator.Results.TicketResults;
using MediatR;

namespace Geair.Application.Mediator.Queries.TicketQueries
{
    public class GetTicketByIdQuery:IRequest<GetTicketByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTicketByIdQuery(int id)
        {
            Id = id;
        }
    }
}