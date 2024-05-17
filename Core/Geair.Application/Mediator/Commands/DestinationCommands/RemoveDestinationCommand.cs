using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.DestinationCommands
{
    public class RemoveDestinationCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveDestinationCommand(int id)
        {
            Id = id;
        }
    }
}
