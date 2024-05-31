using Geair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Interfaces
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlightListAsync();
        Task<List<Flight>> GetAllFlightListByStatusTrueAsync();
        Task<Flight> GetFlightByIdAsync(int id);
    }
}
