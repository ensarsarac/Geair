using AutoMapper;
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
    public class UpdateDestinationCommandHandler : IRequestHandler<UpdateDestinationCommand>
    {
        private readonly IRepository<Destination> _repository;

        public UpdateDestinationCommandHandler( IRepository<Destination> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateDestinationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.DestinationId);
            value.Description = request.Description;
            value.Title = request.Title;
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(value);
        
    }
    }
}
