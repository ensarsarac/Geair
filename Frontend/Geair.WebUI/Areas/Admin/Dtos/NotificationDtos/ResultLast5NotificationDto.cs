namespace Geair.WebUI.Areas.Admin.Dtos.NotificationDtos
{
	public class ResultLast5NotificationDto
	{
		public int NotificationId { get; set; }
		public string Icon { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
	}
}
