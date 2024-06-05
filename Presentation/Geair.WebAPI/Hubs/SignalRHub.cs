using Geair.Application.Mediator.Results.NotificationResults;
using Geair.Persistance.Concrete;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Geair.WebAPI.Hubs
{
    public class SignalRHub:Hub
    {
       private readonly IHttpClientFactory _httpClientFactory;
		public SignalRHub(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task SendNotification()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Notifications/GetLast5NotificationList");
            var value= await res.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("GetLast5Notification", value);
        }
    }
}
