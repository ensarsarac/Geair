﻿namespace Geair.WebUI.Areas.Admin.Dtos.BannersDtos
{
	public class UpdateBannerDto
	{
		public int BannerId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}
