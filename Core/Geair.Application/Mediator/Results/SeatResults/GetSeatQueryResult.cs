using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Results.SeatResults
{
    public class GetSeatQueryResult:IRequest<List<GetSeatQueryResult>>
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public string SeatClass { get; set; }
        public int AircraftId { get; set; }
        public List<Seat> Seats { get; set; }
        public bool IsAvailable { get; set; }
    }
}