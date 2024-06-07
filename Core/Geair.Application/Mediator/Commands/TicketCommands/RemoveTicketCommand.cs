using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Geair.Application.Mediator.Commands.TicketCommands
{
    public class RemoveTicketCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveTicketCommand(int id)
        {
            Id = id;
        }
    }
}