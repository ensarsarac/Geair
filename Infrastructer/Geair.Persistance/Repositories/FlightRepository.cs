﻿using Geair.Application.Interfaces;
using Geair.Domain.Entities;
using Geair.Persistance.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var values = await _context.Flights.Where(x=>x.Status==true).Include(x=>x.Aircraft).Include(x=>x.DepartureAirport).Include(x=>x.ArrivalAirport).OrderByDescending(x => x.FlightId).ToListAsync();
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
    }
}
