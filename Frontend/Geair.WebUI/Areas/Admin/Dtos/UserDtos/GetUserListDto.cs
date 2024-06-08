namespace Geair.WebUI.Areas.Admin.Dtos.UserDtos
{
    public class GetUserListDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string RoleName{ get; set; }
    }
}
