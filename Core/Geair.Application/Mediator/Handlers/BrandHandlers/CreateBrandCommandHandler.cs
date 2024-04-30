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
    public class CreateBrandCommandHandler:IRequestHandler<CreateBrandCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IMapper mapper, IRepository<Brand> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Brand>(request);
            await _repository.CreateAsync(value);
        }
    }
}
