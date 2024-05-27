using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Domain.Entities
{
    public class ReservationTravel
    {
        public int ReservationTravelId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
        public int PersonCount { get; set; }
        public decimal TotalPrice{ get; set; }
        public bool Status { get; set; }
    }
}
