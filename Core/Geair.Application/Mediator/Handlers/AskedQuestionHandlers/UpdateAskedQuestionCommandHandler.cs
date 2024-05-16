using AutoMapper;
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
    public class UpdateAskedQuestionCommandHandler : IRequestHandler<UpdateAskedQuestionCommand>
    {
        private readonly IRepository<AskedQuestion> _repository;

        public UpdateAskedQuestionCommandHandler(IRepository<AskedQuestion> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAskedQuestionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AskedQuestionId);
            value.Title = request.Title;
            value.AskedQuestionId = request.AskedQuestionId;
            value.Description = request.Description;
            value.RowNumber = request.RowNumber;
            await _repository.UpdateAsync(value);
        }
    }
}
