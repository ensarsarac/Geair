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
    public class AircraftRepository : IAircraftRepository
    {
        private readonly Context _context;

        public AircraftRepository(Context context)
        {
            _context = context;
        }

        public async Task<Aircraft> GetAircraftAndSeats(int id)
        {
            var value = await _context.Aircrafts
                                    .Where(x => x.AircraftId == id)
                                    .Select(x => new Aircraft()
                                    {
                                        AircraftId = x.AircraftId,
                                        Seats = x.Seats
                                    })
                                    .FirstOrDefaultAsync();
            return value;
        }
    }
}
