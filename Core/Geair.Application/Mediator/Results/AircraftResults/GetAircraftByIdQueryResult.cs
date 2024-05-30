﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.AircraftResults
{
    public class GetAircraftByIdQueryResult
    {
        public int AircraftId { get; set; }
        public string Model { get; set; }
        public string Capacity { get; set; }
        public string BaggageWeight { get; set; }
    }
}
