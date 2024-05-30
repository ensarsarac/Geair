using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.SeatCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.SeatHandlers
{
    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand>
    {
        private readonly IRepository<Seat> _repository;
        public UpdateSeatCommandHandler(IRepository<Seat> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SeatId);
            value.SeatNumber = request.SeatNumber;
            value.SeatClass = request.SeatClass;
            value.AircraftId = request.AircraftId;
            value.IsAvailable = request.IsAvailable;
            await _repository.UpdateAsync(value);
        }
    }
}
