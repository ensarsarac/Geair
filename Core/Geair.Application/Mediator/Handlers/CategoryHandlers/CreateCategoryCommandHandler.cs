using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.CategoryCommands;
using Geair.Application.Mediator.Queries.CategoryQueries;
using Geair.Application.Mediator.Results.CategoryResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Category>(request));
        }
    }
}
