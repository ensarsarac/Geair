using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.NotificationResults
{
    public class GetLast5NotificationQueryResult:IRequest<List<GetLast5NotificationQueryResult>>
    {
        public int NotificationId { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
