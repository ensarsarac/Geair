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
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand>
    {
        private readonly IRepository<Seat> _repository;
        private readonly IMapper _mapper;
        public CreateSeatCommandHandler(IRepository<Seat> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var result=_mapper.Map<Seat>(request);
            await _repository.CreateAsync(result);
        }
    }
}
