using Geair.Application.Mediator.Results.DestinationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.DestinationQueries
{
    public class GetDestinationByIdQuery:IRequest<GetDestinationByIdQueryResult>
    {
        public int Id { get; set; }

        public GetDestinationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
