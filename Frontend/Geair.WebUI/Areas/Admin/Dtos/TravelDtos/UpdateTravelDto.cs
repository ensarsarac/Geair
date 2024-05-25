namespace Geair.WebUI.Areas.Admin.Dtos.TravelDtos
{
    public class UpdateTravelDto
    {
        public int TravelId { get; set; }
        public string Title { get; set; }
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string CoverImageUrl { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public bool IsFull { get; set; }
    }
}
