using Geair.Application.Mediator.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.UserQueries
{
    public class UserLoginQuery:IRequest<UserLoginQueryResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
