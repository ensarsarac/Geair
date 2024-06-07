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
    public class StatisticRepository:IStatisticRepository
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
    }
}
