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
    public class RemoveCompanyAddressCommandHandler : IRequestHandler<RemoveCompanyAddressCommand>
    {
        private readonly IRepository<CompanyAddress> _repository;

        public RemoveCompanyAddressCommandHandler(IRepository<CompanyAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCompanyAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
