using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.RoleResults
{
    public class GetRoleQueryResult:IRequest<List<GetRoleQueryResult>>
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
