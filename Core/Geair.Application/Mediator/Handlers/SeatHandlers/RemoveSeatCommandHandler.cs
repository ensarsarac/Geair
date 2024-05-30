using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.SeatCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.SeatHandlers
{
    public class RemoveSeatCommandHandler : IRequestHandler<RemoveSeatCommand>
    {
        private readonly IRepository<Seat> _repository;
        public RemoveSeatCommandHandler(IRepository<Seat> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveSeatCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
