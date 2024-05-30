using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Domain.Entities;

namespace Geair.Application.Interfaces
{
    public interface IAircraftRepository
    {
        Task<Aircraft> GetAircraftAndSeats(int id);
    }
}