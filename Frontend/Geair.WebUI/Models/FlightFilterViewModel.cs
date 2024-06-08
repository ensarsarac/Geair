namespace Geair.WebUI.Models
{
    public class FlightFilterViewModel
    {
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
    }
}
