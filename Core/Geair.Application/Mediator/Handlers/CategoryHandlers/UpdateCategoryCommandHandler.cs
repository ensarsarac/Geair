using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.CategoryCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CategoryId);
            value.CategoryName = request.CategoryName;
            await _repository.UpdateAsync(value);
        }
    }
}
