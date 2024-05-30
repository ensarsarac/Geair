using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Domain.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public string SeatClass { get; set; }
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
        public bool IsAvailable { get; set; }
    }
}
