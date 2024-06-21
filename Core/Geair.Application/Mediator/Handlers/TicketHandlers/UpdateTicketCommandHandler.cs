using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.TicketCommands;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Handlers.TicketHandlers
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly IRepository<Ticket> _repository;
        private readonly IMapper _mapper;

        public UpdateTicketCommandHandler(IMapper mapper, IRepository<Ticket> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TicketId);
            value.FlightId = request.FlightId;
            value.UserId = request.UserId;
            value.FlyNumber = request.FlyNumber;
            value.TicketType = request.TicketType;
            value.Name = request.Name;
            value.Surname = request.Surname;
            value.Gender = request.Gender;
            value.Phone = request.Phone;
            value.BirthDate = request.BirthDate;
            value.Email = request.Email;
            value.PersonCount = request.PersonCount;
            value.Status = request.Status;
            await _repository.UpdateAsync(value);
        }
    }
}