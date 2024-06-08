using Geair.Application.Mediator.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.UserQueries
{
    public class GetUserAndRoleQuery:IRequest<GetUserAndRoleQueryResult>
    {
        public int Id { get; set; }

        public GetUserAndRoleQuery(int id)
        {
            Id = id;
        }
    }
}
