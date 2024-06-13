using Geair.Application.Interfaces;
using Geair.Persistance.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Persistance.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> AircraftCount()
        {
            var aircraftCount = await _context.Aircrafts.CountAsync();
            return aircraftCount;
        }

        public async Task<int> AirportCount()
        {
            var airportCount = await _context.Airports.CountAsync();
            return airportCount; 
        }

        public async Task<int> FlightCount()
        {
            var flightCount = await _context.Flights.CountAsync();
            return flightCount;
        }

        public async Task<int> UserCount()
        {
            var userCount = await _context.Users.CountAsync();
            return userCount;
        }

        public async Task<int> TicketCount()
        {
            var ticketCount = await _context.Tickets.CountAsync();
            return ticketCount;
        }

        public async Task<int> BlogCount()
        {
            var blogCount = await _context.Blogs.CountAsync();
            return blogCount;
        }

        public async Task<int> TravelCount()
        {
            var tourCount = await _context.Travels.CountAsync();
            return tourCount;
        }

        public async Task<int> NewsletterCount()
        {
            var count = await _context.Newsletters.CountAsync();
            return count;
        }

        public async Task<int> BlogCategoriesCount()
        {
            var count = await _context.Categories.CountAsync();
            return count;
        }

        public async Task<int> RoleCount()
        {
            var roleCount = await _context.Roles.CountAsync();
            return roleCount;
        }

        public async Task<string> MostCategoryName()
        {
            var result = await _context.Categories.OrderBy(i => i.Blogs.Count()).FirstOrDefaultAsync();
            return result.CategoryName;
        }

        public async Task<string> MostFlyAirport()
        {
            throw new NotImplementedException();
        }

        public async Task<string> MostRegisterTravel()
        {
            var result = await _context.Travels.OrderBy(i => i.ReservationTravels.Count()).FirstOrDefaultAsync();
            return result.Title;
        }

        public async Task<string> MostWriterBlogUser()
        {
            var result = await _context.Users.OrderBy(i => i.Blogs.Count()).FirstOrDefaultAsync();
            return result.Name + " " + result.Surname;
        }

        public async Task<string> LastFlyDateAndHour()
        {
            var result = await _context.Flights.OrderByDescending(i => i.DepartureTime).FirstOrDefaultAsync();
            return result.DepartureTime.ToString("dd/MM/yyyy hh:mm");
        }

        public async Task<string> LastTravelDateAndHour()
        {
            var result = await _context.Travels.OrderByDescending(i => i.StartDate).FirstOrDefaultAsync();
            return result.StartDate.ToString("dd/MM/yyyy hh:mm");
        }
    }
}
