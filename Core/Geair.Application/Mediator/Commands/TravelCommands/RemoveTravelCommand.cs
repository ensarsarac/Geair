using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.TravelCommands
{
    public class RemoveTravelCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveTravelCommand(int id)
        {
            Id = id;
        }
    }
}
