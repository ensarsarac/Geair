using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.DTOLayer.TravelDtos
{
    public class ResultTravelListOrderByDto
    {
        public int TravelId { get; set; }
        public string Title { get; set; }
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string CoverImageUrl { get; set; }
        public int Capacity { get; set; }
    }
}
