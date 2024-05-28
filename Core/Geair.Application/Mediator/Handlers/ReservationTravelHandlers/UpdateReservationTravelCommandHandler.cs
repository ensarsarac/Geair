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
    public class UpdateReservationTravelCommandHandler : IRequestHandler<UpdateReservationTravelCommand>
    {
        private readonly IRepository<ReservationTravel> _repository;

        public UpdateReservationTravelCommandHandler(IRepository<ReservationTravel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReservationTravelCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReservationTravelId);
            value.Surname = request.Surname;
            value.Name = request.Name;
            value.Email = request.Email;
            value.Phone = request.Phone;
            value.TravelId= request.TravelId;
            value.PersonCount = request.PersonCount;
            value.TotalPrice= request.TotalPrice;
            await _repository.UpdateAsync(value);
        }
    }
}
