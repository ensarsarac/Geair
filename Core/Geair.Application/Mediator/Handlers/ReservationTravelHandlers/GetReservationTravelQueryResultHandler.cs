using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.ReservationTravelResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.ReservationTravelHandlers
{
    public class GetReservationTravelQueryResultHandler : IRequestHandler<GetReservationTravelQueryResult, List<GetReservationTravelQueryResult>>
    {
        private readonly IReservationTravelRepository _repository;

        public GetReservationTravelQueryResultHandler(IReservationTravelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationTravelQueryResult>> Handle(GetReservationTravelQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllReservationTravelWithInclude();
            var result = values.Select(x => new GetReservationTravelQueryResult
            {
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone=x.Phone,
                UserId = x.UserId,
                PersonCount = x.PersonCount,
                ReservationTravelId = x.ReservationTravelId,
                TravelId= x.TravelId,
                UserNameSurname=x.User.Name+" "+x.User.Surname
            }).ToList();
            return result;
        }
    }
}
