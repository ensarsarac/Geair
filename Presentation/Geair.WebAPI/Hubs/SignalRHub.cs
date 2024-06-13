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
            #region AircraftCount
            var client5 = _httpClientFactory.CreateClient();
            var TicketCountResponse = await client5.GetAsync("https://localhost:7151/api/Statistics/GetTicketCount");
            var TicketCountRead = await TicketCountResponse.Content.ReadAsStringAsync();
            var TicketCountValue = JsonConvert.DeserializeObject<int>(TicketCountRead);
            await Clients.All.SendAsync("ReceiveTicketCount", TicketCountValue);
            #endregion
            #region BlogCount
            var client6 = _httpClientFactory.CreateClient();
            var BlogCountresponse = await client6.GetAsync("https://localhost:7151/api/Statistics/GetBlogCount");
            var BlogCountRead = await BlogCountresponse.Content.ReadAsStringAsync();
            var BlogCOuntValue = JsonConvert.DeserializeObject<int>(BlogCountRead);
            await Clients.All.SendAsync("ReceiveBlogCount", BlogCOuntValue);
            #endregion
            #region TravelCount
            var client7 = _httpClientFactory.CreateClient();
            var TravelCountresponse = await client7.GetAsync("https://localhost:7151/api/Statistics/GetTravelCount");
            var TravelCountRead = await TravelCountresponse.Content.ReadAsStringAsync();
            var TravelCountValue = JsonConvert.DeserializeObject<int>(TravelCountRead);
            await Clients.All.SendAsync("ReceiveTravelCount", TravelCountValue);
            #endregion
            #region NewsletterCount
            var client8 = _httpClientFactory.CreateClient();
            var NewsletterCountresponse = await client8.GetAsync("https://localhost:7151/api/Statistics/GetNewsletterCount");
            var NewsletterCountRead = await NewsletterCountresponse.Content.ReadAsStringAsync();
            var NewsletterCountValue = JsonConvert.DeserializeObject<int>(NewsletterCountRead);
            await Clients.All.SendAsync("ReceiveNewsletterCount", NewsletterCountValue);
            #endregion
            #region BlogCategoriesCount
            var client9 = _httpClientFactory.CreateClient();
            var blogCategoriesCountresponse = await client9.GetAsync("https://localhost:7151/api/Statistics/GetBlogCategoriesCount");
            var blogCategoriesCountRead = await blogCategoriesCountresponse.Content.ReadAsStringAsync();
            var blogCategoriesCountValue = JsonConvert.DeserializeObject<int>(blogCategoriesCountRead);
            await Clients.All.SendAsync("ReceiveBlogCategoriesCount", blogCategoriesCountValue);
            #endregion
            #region RoleCount
            var client10 = _httpClientFactory.CreateClient();
            var roleCountRes = await client10.GetAsync("https://localhost:7151/api/Statistics/GetRoleCount");
            var roleCountRead = await roleCountRes.Content.ReadAsStringAsync();
            var roleCountValue = JsonConvert.DeserializeObject<int>(roleCountRead);
            await Clients.All.SendAsync("ReceiveRoleCount", roleCountValue);
            #endregion




            #region LastFlyDateAndHour
            var client11 = _httpClientFactory.CreateClient();
            var lastFlyDateAndHourRes = await client11.GetAsync("https://localhost:7151/api/Statistics/GetLastFlyDateAndHour");
            var lastFlyDateAndHourRead = await lastFlyDateAndHourRes.Content.ReadAsStringAsync();
            // var lastFlyDateAndHourValue = JsonConvert.DeserializeObject<string>(lastFlyDateAndHourRead);
            await Clients.All.SendAsync("ReceiveLastFlyDateAndHour", lastFlyDateAndHourRead);
            #endregion

            #region LastTravelDateAndHour
            var client12 = _httpClientFactory.CreateClient();
            var lastTravelDateAndHourRes = await client12.GetAsync("https://localhost:7151/api/Statistics/GetLastTravelDateAndHour");
            var lastTravelDateAndHourRead = await lastTravelDateAndHourRes.Content.ReadAsStringAsync();
            // var lastTravelDateAndHourValue = JsonConvert.DeserializeObject<string>(lastTravelDateAndHourRead);
            await Clients.All.SendAsync("ReceiveLastTravelDateAndHour", lastTravelDateAndHourRead);
            #endregion

            #region MostCategoryName
            var client13 = _httpClientFactory.CreateClient();
            var mostCategoryNameRes = await client13.GetAsync("https://localhost:7151/api/Statistics/GetMostCategoryName");
            var mostCategoryNameRead = await mostCategoryNameRes.Content.ReadAsStringAsync();
            // var mostCategoryNameValue = JsonConvert.DeserializeObject<string>(mostCategoryNameRead);
            await Clients.All.SendAsync("ReceiveMostCategoryName", mostCategoryNameRead);
            #endregion

            #region MostRegisterTravel
            var client14 = _httpClientFactory.CreateClient();
            var mostRegisterTravelRes = await client14.GetAsync("https://localhost:7151/api/Statistics/GetMostRegisterTravel");
            var mostRegisterTravelRead = await mostRegisterTravelRes.Content.ReadAsStringAsync();
            // var mostRegisterTravelValue = JsonConvert.DeserializeObject<string>(mostRegisterTravelRead);
            await Clients.All.SendAsync("ReceiveMostRegisterTravel", mostRegisterTravelRead);
            #endregion

            #region MostWriterBlogUser
            var client15 = _httpClientFactory.CreateClient();
            var mostWriterBlogUserRes = await client15.GetAsync("https://localhost:7151/api/Statistics/GetMostWriterBlogUser");
            var mostWriterBlogUserRead = await mostWriterBlogUserRes.Content.ReadAsStringAsync();
            // var mostWriterBlogUserValue = JsonConvert.DeserializeObject<string>(mostWriterBlogUserRead);
            await Clients.All.SendAsync("ReceiveMostWriterBlogUser", mostWriterBlogUserRead);
            #endregion
        }
    }
}
