using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.ReservationTravelQueries;
using Geair.Application.Mediator.Results.ReservationTravelResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.ReservationTravelHandlers
{
    public class GetReservationTravelByIdQueryResultHandler : IRequestHandler<GetReservationTravelByIdQuery, GetReservationTravelByIdQueryResult>
    {
        private readonly IReservationTravelRepository _reservationTravelRepository;

        public GetReservationTravelByIdQueryResultHandler(IReservationTravelRepository reservationTravelRepository)
        {
            _reservationTravelRepository = reservationTravelRepository;
        }

        public async Task<GetReservationTravelByIdQueryResult> Handle(GetReservationTravelByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _reservationTravelRepository.GetReservationTravelByIdWithInclude(request.Id);
            return new GetReservationTravelByIdQueryResult
            {
                Email = value.Email,
                Name=value.Name,
                PersonCount=value.PersonCount,
                Phone=value.Phone,
                ReservationTravelId=value.ReservationTravelId,
                Surname=value.Surname,
                TravelId=value.TravelId,
                UserId = value.UserId != null ? value.UserId : null,
                TotalPrice=value.TotalPrice,
                TravelTitle=value.Travel.Title,
                UserNameSurname= value.UserId != null ? value.User.Name + " " + value.User.Surname : null,
            };
        }
    }
}
