using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.AskedQuestionCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AskedQuestionHandlers
{
    public class RemoveAskedQuestionCommandHandler:IRequestHandler<RemoveAskedQuestionCommand>
    {
        private readonly IRepository<AskedQuestion> _repository;

        public RemoveAskedQuestionCommandHandler(IRepository<AskedQuestion> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAskedQuestionCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
