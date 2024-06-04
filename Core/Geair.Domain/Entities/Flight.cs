using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Domain.Entities
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public int DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        public int ArrivalAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime{ get; set; }
        public int AircraftId{ get; set; }
        public Aircraft Aircraft{ get; set; }
        public decimal EconomyPrice{ get; set; }
        public decimal BusinessPrice{ get; set; }
        public string FlightType { get; set; }
        public DateTime? DateOfReturn { get; set; }
        public bool Status { get; set; }
    }
}
