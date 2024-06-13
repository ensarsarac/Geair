using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Interfaces
{
    public interface IStatisticRepository
    {
        Task<int> UserCount();
        Task<int> RoleCount();
        Task<int> FlightCount();
        Task<int> AirportCount();
        Task<int> AircraftCount();
        Task<int> TicketCount();
        Task<int> BlogCount();
        Task<int> TravelCount();
        Task<int> NewsletterCount();
        Task<int> BlogCategoriesCount();
        Task<string> MostCategoryName(); // En çok kullanılan kategori
        Task<string> MostFlyAirport(); // En çok uçuş olan havaalanı
        Task<string> MostRegisterTravel(); // En çok kayıt alan tur
        Task<string> MostWriterBlogUser(); // En çok blog yazan user
        Task<string> LastFlyDateAndHour(); // En son uçuş tarihi ve saati
        Task<string> LastTravelDateAndHour(); // En son tur tarihi ve saati
    }
}
