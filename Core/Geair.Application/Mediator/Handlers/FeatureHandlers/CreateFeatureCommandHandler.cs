using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.FeatureCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public CreateFeatureCommandHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Feature>(request);
            await _repository.CreateAsync(value);
        }
    }
}
