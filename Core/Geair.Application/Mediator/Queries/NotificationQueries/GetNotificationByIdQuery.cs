using Geair.Application.Mediator.Results.NotificationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.NotificationQueries
{
    public class GetNotificationByIdQuery:IRequest<GetNotificationByIdQueryResult>
    {
        public int Id { get; set; }

        public GetNotificationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
