using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.ReservationTravelResults
{
    public class GetReservationTravelQueryResult:IRequest<List<GetReservationTravelQueryResult>>
    {
        public int ReservationTravelId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? UserNameSurname { get; set; }
        public int? UserId { get; set; }
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
        public int PersonCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
