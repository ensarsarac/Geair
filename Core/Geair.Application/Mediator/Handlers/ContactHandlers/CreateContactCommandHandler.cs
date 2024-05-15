using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.ContactCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            request.Date = DateTime.Now;    
            var value = _mapper.Map<Contact>(request);
            await _repository.CreateAsync(value);
        }
    }
}
