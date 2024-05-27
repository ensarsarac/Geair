using Geair.Application.Interfaces;
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
    public class TravelRepository : ITravelRepository
    {
        private readonly Context _context;

        public TravelRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Travel>> GetLast4TravelListAsync()
        {
            var values = await _context.Travels.OrderByDescending(x => x.TravelId).Where(x => x.Status == true && x.IsFull==false).Take(4).ToListAsync();
            return values;
        }

        public async Task<Travel> GetTravelAndReservations(int id)
        {
            var value = await _context.Travels
            .Where(x => x.TravelId == id)
            // .Include(x => x.ReservationTravels)
            .Select(x => new Travel()
            {
                TravelId = x.TravelId,
                ReservationTravels = x.ReservationTravels
            })
            .FirstOrDefaultAsync();
            return value;
        }

        public async Task<List<Travel>> GetTravelListOrderBy()
        {
            var values = await _context.Travels.OrderByDescending(x => x.TravelId).ToListAsync();
            return values;
        }
    }
}
