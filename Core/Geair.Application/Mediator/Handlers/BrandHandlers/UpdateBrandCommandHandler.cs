using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.BrandCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BrandId);
            value.BrandName = request.BrandName;
            value.BrandId = request.BrandId;
            value.Logo = request.Logo;
            await _repository.UpdateAsync(value);
        }
    }
}
