using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.NotificationCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.NotificationHandlers
{
    public class RemoveNotificationCommandHandler : IRequestHandler<RemoveNotificationCommand>
    {
        private readonly IRepository<Notification> _repository;

        public RemoveNotificationCommandHandler(IRepository<Notification> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveNotificationCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
