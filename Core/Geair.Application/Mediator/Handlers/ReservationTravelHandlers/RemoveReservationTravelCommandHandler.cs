using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.ReservationTravelCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.ReservationTravelHandlers
{
    public class RemoveReservationTravelCommandHandler : IRequestHandler<RemoveReservationTravelCommand>
    {
        private readonly IRepository<ReservationTravel> _reservationTravelRepository;

        public RemoveReservationTravelCommandHandler(IRepository<ReservationTravel> reservationTravelRepository)
        {
            _reservationTravelRepository = reservationTravelRepository;
        }

        public async Task Handle(RemoveReservationTravelCommand request, CancellationToken cancellationToken)
        {
            await _reservationTravelRepository.DeleteAsync(request.Id);
        }
    }
}
