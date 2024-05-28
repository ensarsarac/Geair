using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.ReservationTravelCommands
{
    public class UpdateReservationTravelStatusTrueCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateReservationTravelStatusTrueCommand(int id)
        {
            Id = id;
        }
    }
}
