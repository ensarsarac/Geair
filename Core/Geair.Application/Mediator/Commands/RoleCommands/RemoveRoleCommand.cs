using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.RoleCommands
{
    public class RemoveRoleCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveRoleCommand(int id)
        {
            Id = id;
        }
    }
}
