namespace Geair.WebUI.Areas.Admin.Dtos.AircraftDtos
{
    public class UpdateAircraftDto
    {
        public int AircraftId { get; set; }
        public string Model { get; set; }
        public string Capacity { get; set; }
        public string BaggageWeight { get; set; }
    }
}
