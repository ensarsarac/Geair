using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.BlogCommands;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler:IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}