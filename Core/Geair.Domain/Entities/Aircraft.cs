using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Domain.Entities
{
    public class Aircraft
    {
        public int AircraftId { get; set; }
        public string Model { get; set; }
        public string Capacity { get; set; }
        public string BaggageWeight { get; set; }
        public List<Seat> Seats{ get; set; }
        public List<Flight> Flights{ get; set; }
    }
}
