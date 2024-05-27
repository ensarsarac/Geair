using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Results.TravelResults
{
    public class GetTravelAndReservationsQueryResult
    {
        public int TravelId { get; set; }
        public List<ReservationTravel> ReservationTravels { get; set; }
    }
}