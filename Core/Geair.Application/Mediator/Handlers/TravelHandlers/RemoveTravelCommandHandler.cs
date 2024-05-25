using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.TravelCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.TravelHandlers
{
    public class RemoveTravelCommandHandler : IRequestHandler<RemoveTravelCommand>
    {
        private readonly IRepository<Travel> _repository;

        public RemoveTravelCommandHandler(IRepository<Travel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTravelCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}