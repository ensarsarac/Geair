using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.NotificationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.NotificationHandlers
{
    public class GetLast5NotificationQueryResultHandler : IRequestHandler<GetLast5NotificationQueryResult, List<GetLast5NotificationQueryResult>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetLast5NotificationQueryResultHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public async Task<List<GetLast5NotificationQueryResult>> Handle(GetLast5NotificationQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _notificationRepository.GetLast5Notification();
            return _mapper.Map<List<GetLast5NotificationQueryResult>>(values);
        }
    }
}
