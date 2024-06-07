using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geair.WebUI.Areas.Admin.Dtos.TicketDtos
{
    public class UpdateTicketDto
    {
        public int TicketId { get; set; }
        public int FlightId { get; set; }
        public int? UserId { get; set; }
        public int PersonCount { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string FlyNumber { get; set; }
        public string TicketType { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}