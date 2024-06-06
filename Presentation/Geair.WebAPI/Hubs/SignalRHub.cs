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
        public async Task SendStatistic()
        {

            #region UserCount
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7151/api/Statistics/GetUserCount");
            var read = await res.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<int>(read);
            await Clients.All.SendAsync("ReceiveUserCount", value);
            #endregion
            #region FlightCount
            var client2 = _httpClientFactory.CreateClient();
            var flightCountResponse= await client2.GetAsync("https://localhost:7151/api/Statistics/GetFlightCount");
            var flightCountRead = await flightCountResponse.Content.ReadAsStringAsync();
            var flightCountValue = JsonConvert.DeserializeObject<int>(flightCountRead);
            await Clients.All.SendAsync("ReceiveFlightCount", flightCountValue);
            #endregion
            #region AirportCount
            var client3 = _httpClientFactory.CreateClient();
            var AirportCountResponse = await client3.GetAsync("https://localhost:7151/api/Statistics/GetAirportCount");
            var AirportCountRead = await AirportCountResponse.Content.ReadAsStringAsync();
            var AirportCountValue = JsonConvert.DeserializeObject<int>(AirportCountRead);
            await Clients.All.SendAsync("ReceiveAirportCount", AirportCountValue);
            #endregion
            #region AircraftCount
            var client4 = _httpClientFactory.CreateClient();
            var AircraftCountResponse = await client4.GetAsync("https://localhost:7151/api/Statistics/GetAircraftCount");
            var AircraftCountRead = await AircraftCountResponse.Content.ReadAsStringAsync();
            var AircraftCountValue = JsonConvert.DeserializeObject<int>(AircraftCountRead);
            await Clients.All.SendAsync("ReceiveAircraftCount", AircraftCountValue);
            #endregion
        }
    }
}
