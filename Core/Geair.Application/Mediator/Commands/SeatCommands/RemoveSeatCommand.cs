using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.SeatCommands
{
    public class RemoveSeatCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveSeatCommand(int id)
        {
            Id = id;
        }
    }
}
