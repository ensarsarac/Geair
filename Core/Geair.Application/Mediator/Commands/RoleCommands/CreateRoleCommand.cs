using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.RoleCommands
{
    public class CreateRoleCommand:IRequest
    {
        public string RoleName { get; set; }
    }
}
