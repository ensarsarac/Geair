using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.DestinationResults
{
    public class GetDestinationListQueryResult:IRequest<List<GetDestinationListQueryResult>>
    {
        public int DestinationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
