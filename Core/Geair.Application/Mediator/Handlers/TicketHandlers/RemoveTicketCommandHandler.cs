using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.TicketCommands;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Handlers.TicketHandlers
{
    public class RemoveTicketCommandHandler : IRequestHandler<RemoveTicketCommand>
    {
        private readonly IRepository<Ticket> _repository;

        public RemoveTicketCommandHandler(IRepository<Ticket> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTicketCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}