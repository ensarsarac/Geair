using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.FlightCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FlightHandlers
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand>
    {
        private readonly IRepository<Flight> _flightRepository;
        private readonly IMapper _mapper;

        public CreateFlightCommandHandler(IRepository<Flight> flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Flight>(request);
            result.FlightNumber= Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
            await _flightRepository.CreateAsync(result);
        }
    }
}
