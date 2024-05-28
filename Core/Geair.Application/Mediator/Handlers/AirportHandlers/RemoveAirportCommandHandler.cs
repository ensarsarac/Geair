using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.AirportCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AirportHandlers
{
    public class RemoveAirportCommandHandler : IRequestHandler<RemoveAirportCommand>
    {
        private readonly IRepository<Airport> _repository;

        public RemoveAirportCommandHandler(IRepository<Airport> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAirportCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
