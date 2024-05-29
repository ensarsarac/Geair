using Geair.Application.Mediator.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.UserQueries
{
    public class GetUserImageAndNameQuery:IRequest<GetUserImageAndNameQueryResult>
    {
        public int Id { get; set; }

        public GetUserImageAndNameQuery(int id)
        {
            Id = id;
        }
    }
}
