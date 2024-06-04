using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.TicketCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.TicketHandlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
        private readonly IRepository<Ticket> _repository;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(IRepository<Ticket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Ticket>(request));
        }
    }
}
