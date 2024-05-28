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
    public class ReservationTravelRepository : IReservationTravelRepository
    {
        private readonly Context _context;

        public ReservationTravelRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ReservationTravel>> GetAllReservationTravelWithInclude()
        {
            var values = await _context.ReservationTravels.Include(x => x.User).Include(x => x.Travel).ToListAsync();
            return values;
        }

        public async Task<ReservationTravel> GetReservationTravelByIdWithInclude(int id)
        {
            var value = await _context.ReservationTravels.Include(x => x.User).Include(x => x.Travel).Where(x => x.ReservationTravelId == id).FirstOrDefaultAsync();
            return value;
        }
        public async Task ReservationTravelStatusTrue(int id)
        {
            var value = await _context.ReservationTravels.Where(x => x.ReservationTravelId == id).FirstOrDefaultAsync();
            value.Status = true;
            await _context.SaveChangesAsync();
        }
    }
}
