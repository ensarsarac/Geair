using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Domain.Entities;

namespace Geair.Application.Mediator.Results.AircraftResults
{
    public class GetAircraftAndSeatsQueryResult
    {
        public int AircraftId { get; set; }
        public List<Seat> Seats { get; set; }
    }
}