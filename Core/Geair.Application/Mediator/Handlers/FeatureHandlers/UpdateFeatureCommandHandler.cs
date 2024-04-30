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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FeatureId);
            value.FeatureId = request.FeatureId;
            value.Title = request.Title;
            value.Description=request.Description;
            value.Icon=request.Icon;
            await _repository.UpdateAsync(value);
        }
    }
}
