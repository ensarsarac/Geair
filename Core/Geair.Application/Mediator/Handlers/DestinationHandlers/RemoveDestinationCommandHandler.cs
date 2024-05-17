using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.DestinationCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler : IRequestHandler<RemoveDestinationCommand>
    {
        private readonly IRepository<Destination> _repository;

        public RemoveDestinationCommandHandler(IRepository<Destination> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveDestinationCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
