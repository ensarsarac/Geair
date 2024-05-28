namespace Geair.WebUI.Areas.Admin.Dtos.ReservationTravelDtos
{
    public class GetReservationTravelDto
    {
        public int ReservationTravelId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TravelId { get; set; }
        public string TravelTitle { get; set; }
        public int PersonCount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}
