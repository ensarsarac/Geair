using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.FlightOptionCommands
{
    public class RemoveFlightOptionCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveFlightOptionCommand(int id)
        {
            Id = id;
        }
    }
}
