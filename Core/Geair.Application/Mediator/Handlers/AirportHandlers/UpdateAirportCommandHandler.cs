using AutoMapper;
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
    public class UpdateAirportCommandHandler : IRequestHandler<UpdateAirportCommand>
    {
        private readonly IRepository<Airport> _repository;
        private readonly IMapper _mapper;

        public UpdateAirportCommandHandler(IMapper mapper, IRepository<Airport> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AirportId);
            value.AirportTitle=request.AirportTitle;
            await _repository.UpdateAsync(value);
        }
    }
}
