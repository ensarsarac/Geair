using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.FlightResults
{
    public class GetFlightByStatusTrueQueryResult:IRequest<List<GetFlightByStatusTrueQueryResult>>
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public int DepartureAirportId { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureAirportCity { get; set; }
        public int ArrivalAirportId { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalAirportCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AircraftId { get; set; }
        public string AircraftModel { get; set; }
        public decimal AircraftBaggageWeightPerson { get; set; }
        public decimal EconomyPrice { get; set; }
        public decimal BusinessPrice { get; set; }
        public bool Status { get; set; }
    }
}
