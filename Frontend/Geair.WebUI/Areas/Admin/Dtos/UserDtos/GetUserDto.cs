namespace Geair.WebUI.Areas.Admin.Dtos.UserDtos
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
