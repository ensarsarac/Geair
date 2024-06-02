namespace Geair.WebUI.Areas.Admin.Dtos.FlightDtos
{
    public class UpdateFlightDto
    {
        public int FlightId { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AircraftId { get; set; }
        public decimal EconomyPrice { get; set; }
        public decimal BusinessPrice { get; set; }
    }
}
