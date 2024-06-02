using Geair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Interfaces
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlightListAsync();
        Task<List<Flight>> GetAllFlightListByFilterAsync(string FromWhere,string ToWhere,DateTime Departure,DateTime Arrival);
        Task<List<Flight>> GetAllFlightListByStatusTrueAsync();
        Task<Flight> GetFlightByIdAsync(int id);
    }
}
