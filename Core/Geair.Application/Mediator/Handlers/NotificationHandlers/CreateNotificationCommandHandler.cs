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
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand>
    {
        private readonly IRepository<Notification> _repository;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(IMapper mapper, IRepository<Notification> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Notification>(request));  
        }
    }
}
