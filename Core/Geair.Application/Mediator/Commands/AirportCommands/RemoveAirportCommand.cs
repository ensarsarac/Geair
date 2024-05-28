using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.AirportCommands
{
    public class RemoveAirportCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveAirportCommand(int id)
        {
            Id = id;
        }
    }
}
