using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.FeatureCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
