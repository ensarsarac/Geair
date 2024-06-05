using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.NotificationQueries;
using Geair.Application.Mediator.Results.NotificationResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.NotificationHandlers
{
    public class GetNotificationByIdQueryResultHandler:IRequestHandler<GetNotificationByIdQuery,GetNotificationByIdQueryResult>
    {
        private readonly IRepository<Notification> _repository;
        private readonly IMapper _mapper;

        public GetNotificationByIdQueryResultHandler(IRepository<Notification> notificationRepository, IMapper mapper)
        {
            _repository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<GetNotificationByIdQueryResult> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetNotificationByIdQueryResult>(value);
        }
    }
}
