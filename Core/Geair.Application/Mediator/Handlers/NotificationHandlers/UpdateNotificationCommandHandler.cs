using AutoMapper;
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
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand>
    {
        private readonly IRepository<Notification> _repository;

        public UpdateNotificationCommandHandler(IRepository<Notification> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.NotificationId);
            value.Description = request.Description;
            value.Date = request.Date;
            value.Icon = request.Icon;
            value.Title = request.Title;
            await _repository.UpdateAsync(value);
        }
    }
}
