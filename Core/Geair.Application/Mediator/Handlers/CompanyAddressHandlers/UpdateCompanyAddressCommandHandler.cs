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
    public class UpdateCompanyAddressCommandHandler : IRequestHandler<UpdateCompanyAddressCommand>
    {
        private readonly IRepository<CompanyAddress> _repository;

        public UpdateCompanyAddressCommandHandler( IRepository<CompanyAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCompanyAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CompanyAddressId);
            value.Phone = request.Phone;
            value.Address = request.Address;
            value.Email= request.Email;
            value.CompanyAddressId = request.CompanyAddressId;
            await _repository.UpdateAsync(value);
        }
    }
}
