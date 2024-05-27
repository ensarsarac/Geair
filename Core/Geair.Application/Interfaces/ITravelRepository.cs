using Geair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Interfaces
{
    public interface ITravelRepository
    {
        Task<List<Travel>> GetLast4TravelListAsync();
        Task<List<Travel>> GetTravelListOrderBy();
    }
}
