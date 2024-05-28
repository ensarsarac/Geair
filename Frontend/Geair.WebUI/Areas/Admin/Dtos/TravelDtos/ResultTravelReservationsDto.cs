using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Domain.Entities;

namespace Geair.WebUI.Areas.Admin.Dtos.TravelDtos
{
    public class ResultTravelReservationsDto
    {
        public int TravelId { get; set; }
        public bool Status{ get; set; }
        public List<ReservationTravel> ReservationTravels { get; set; }
    }
}