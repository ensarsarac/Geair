using Geair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Interfaces
{
    public interface IReservationTravelRepository
    {
        Task<List<ReservationTravel>> GetAllReservationTravelWithInclude();
        Task<ReservationTravel> GetReservationTravelByIdWithInclude(int id);
        Task ReservationTravelStatusTrue(int id);
    }
}
