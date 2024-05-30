using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.AircraftCommands
{
    public class RemoveAircraftCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveAircraftCommand(int id)
        {
            Id = id;
        }
    }
}
