using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.SeatCommands
{
    public class CreateSeatCommand:IRequest
    {
        public string SeatNumber { get; set; }
        public string SeatClass { get; set; }
        public int AircraftId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
