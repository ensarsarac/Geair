using Geair.Application.Mediator.Results.RoleResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.RoleQueries
{
    public class GetRoleByIdQuery:IRequest<GetRoleByIdQueryResult>
    {
        public int Id { get; set; }

        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
