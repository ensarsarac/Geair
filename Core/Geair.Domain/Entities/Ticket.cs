﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
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
