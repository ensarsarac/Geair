namespace Geair.WebUI.Models
{
    public class GetUserProfileDto
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string imageUrl { get; set; }
        public IFormFile? imageFile { get; set; }
        public string imageStorageName { get; set; }
    }
}
