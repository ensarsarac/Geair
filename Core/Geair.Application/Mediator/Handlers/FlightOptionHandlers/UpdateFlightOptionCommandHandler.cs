using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.FlightOptionCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FlightOptionHandlers
{
    public class UpdateFlightOptionCommandHandler : IRequestHandler<UpdateFlightOptionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FlightOptions> _repository;

        public UpdateFlightOptionCommandHandler(IRepository<FlightOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateFlightOptionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FlightOptionsId);
            value.FlightOptionsId = request.FlightOptionsId;
            value.Title = request.Title;
            value.Description1 = request.Description1;
            value.Description2 = request.Description2;
            value.Description3= request.Description3;
            value.Icon = request.Icon;
            await _repository.UpdateAsync(value);
        }
    }
}
