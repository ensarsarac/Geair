using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.UserCommands
{
	public class UpdateUserRoleCommand:IRequest
	{
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
