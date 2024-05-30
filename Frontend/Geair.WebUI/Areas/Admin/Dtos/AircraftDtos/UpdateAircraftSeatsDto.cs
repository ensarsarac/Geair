using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Domain.Entities;

namespace Geair.WebUI.Areas.Admin.Dtos.AircraftDtos
{
    public class UpdateAircraftSeatsDto
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public string SeatClass { get; set; }
        public int AircraftId { get; set; }
        public bool IsAvailable { get; set; }
    }
}