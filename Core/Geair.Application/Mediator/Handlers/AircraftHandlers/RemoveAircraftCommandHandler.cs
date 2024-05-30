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
    public class RemoveAircraftCommandHandler : IRequestHandler<RemoveAircraftCommand>
    {
        private readonly IRepository<Aircraft> _repository;
        private readonly IMapper _mapper;

        public RemoveAircraftCommandHandler(IRepository<Aircraft> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(RemoveAircraftCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
