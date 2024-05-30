using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.AircraftCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AircraftHandlers
{
    public class UpdateAircraftCommandHandler : IRequestHandler<UpdateAircraftCommand>
    {
        private readonly IRepository<Aircraft> _repository;
        private readonly IMapper _mapper;

        public UpdateAircraftCommandHandler(IRepository<Aircraft> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateAircraftCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AircraftId);
            value.Model = request.Model;
            value.Capacity = request.Capacity;
            value.BaggageWeight = request.BaggageWeight;
            await _repository.UpdateAsync(value);
        }
    }
}
