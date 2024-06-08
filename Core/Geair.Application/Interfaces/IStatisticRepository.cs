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
        Task<int> FlightCount();
        Task<int> AirportCount();
        Task<int> AircraftCount();
        Task<int> TicketCount();
        Task<int> BlogCount();
        Task<int> TravelCount();
        Task<int> NewsletterCount();
    }
}
