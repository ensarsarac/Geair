using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.AirportCommands
{
    public class CreateAirportCommand:IRequest
    {
        public string AirportTitle { get; set; }
        public string City { get; set; }
    }
}
