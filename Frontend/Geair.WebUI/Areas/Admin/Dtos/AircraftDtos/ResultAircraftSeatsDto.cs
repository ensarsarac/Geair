using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Domain.Entities;

namespace Geair.WebUI.Areas.Admin.Dtos.AircraftDtos
{
    public class ResultAircraftSeatsDto
    {
        public int AircraftId { get; set; }
        public List<Seat> Seats { get; set; }
    }
}