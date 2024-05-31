using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.FlightCommands
{
    public class RemoveFlightCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveFlightCommand(int id)
        {
            Id = id;
        }
    }
}
