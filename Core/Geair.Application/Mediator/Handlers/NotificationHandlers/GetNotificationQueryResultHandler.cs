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
    public class GetNotificationQueryResultHandler : IRequestHandler<GetNotificationQueryResult, List<GetNotificationQueryResult>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetNotificationQueryResultHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<List<GetNotificationQueryResult>> Handle(GetNotificationQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _notificationRepository.GetAllNotification();
            return _mapper.Map<List<GetNotificationQueryResult>>(values);
        }
    }
}
