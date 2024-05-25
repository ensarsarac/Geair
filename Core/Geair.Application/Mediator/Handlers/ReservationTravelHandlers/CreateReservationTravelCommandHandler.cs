using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.ReservationTravelCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.ReservationTravelHandlers
{
    public class CreateReservationTravelCommandHandler : IRequestHandler<CreateReservationTravelCommand>
    {
        private readonly IRepository<ReservationTravel> _repository;
        private readonly IMapper _mapper;

        public CreateReservationTravelCommandHandler(IRepository<ReservationTravel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateReservationTravelCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<ReservationTravel>(request);
            await _repository.CreateAsync(result);
        }
    }
}
