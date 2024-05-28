using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.ReservationTravelCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.ReservationTravelHandlers
{
    public class ReservationTravelStatusTrueCommandHandler : IRequestHandler<UpdateReservationTravelStatusTrueCommand>
    {
        private readonly IReservationTravelRepository _reservationTravelRepository;

        public ReservationTravelStatusTrueCommandHandler(IReservationTravelRepository reservationTravelRepository)
        {
            _reservationTravelRepository = reservationTravelRepository;
        }

        public async Task Handle(UpdateReservationTravelStatusTrueCommand request, CancellationToken cancellationToken)
        {
            await _reservationTravelRepository.ReservationTravelStatusTrue(request.Id);
        }
    }
}
