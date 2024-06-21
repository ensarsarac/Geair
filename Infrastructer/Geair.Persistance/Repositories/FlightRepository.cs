using Geair.Application.Interfaces;
using Geair.Domain.Entities;
using Geair.Persistance.Concrete;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Persistance.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly Context _context;

        public FlightRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAllFlightListByStatusTrueAsync()
        {
            var flights = await _context.Flights.ToListAsync();
            foreach (var item in flights)
            {
                if(item.DepartureTime <= DateTime.Now)
                {
                    item.Status = false;
                    await _context.SaveChangesAsync();
                }
            }
            var values = await _context.Flights.Where(x => x.Status == true).Include(x => x.Aircraft).Include(x => x.DepartureAirport).Include(x => x.ArrivalAirport).OrderByDescending(x => x.FlightId).ToListAsync();
            return values;
        }
        public async Task<List<Flight>> GetAllFlightListAsync()
        {
            var values = await _context.Flights.Include(x => x.Aircraft).Include(x => x.DepartureAirport).Include(x => x.ArrivalAirport).OrderByDescending(x => x.FlightId).ToListAsync();
            return values;
        }
        public async Task<Flight> GetFlightByIdAsync(int id)
        {
            var value = await _context.Flights.Where(x => x.FlightId == id).Include(x => x.Aircraft).Include(x => x.DepartureAirport).Include(x => x.ArrivalAirport).OrderByDescending(x => x.FlightId).FirstOrDefaultAsync();
            return value;
        }

        public async Task<List<Flight>> GetAllFlightListByFilterAsync(string FromWhere, string ToWhere, DateTime Departure, DateTime Arrival)
        {
            var values = await _context.Flights.Include(x => x.DepartureAirport).Include(x => x.ArrivalAirport).Include(x => x.Aircraft).Where(x => x.DepartureTime >= Departure & x.ArrivalTime <= Arrival & x.DepartureAirport.City.ToLower().Contains(FromWhere) & x.ArrivalAirport.City.ToLower().Contains(ToWhere)).ToListAsync();
            return values;
        }
    }
}
