using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.CompanyAddressCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.CompanyAddressHandlers
{
    public class CreateCompanyAddressCommandHandler : IRequestHandler<CreateCompanyAddressCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyAddress> _repository;

        public CreateCompanyAddressCommandHandler(IMapper mapper, IRepository<CompanyAddress> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task Handle(CreateCompanyAddressCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<CompanyAddress>(request);
            await _repository.CreateAsync(result);
        }
    }
}
