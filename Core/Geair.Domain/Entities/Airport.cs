using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geair.Domain.Entities
{
    public class Airport
    {
        public int AirportId { get; set; }
        public string AirportTitle { get; set; }
        public string City { get; set; }
        public List<Flight> DepartureAirportFlight{ get; set; }
        public List<Flight> ArrivalAirportFlight{ get; set; }
    }
}