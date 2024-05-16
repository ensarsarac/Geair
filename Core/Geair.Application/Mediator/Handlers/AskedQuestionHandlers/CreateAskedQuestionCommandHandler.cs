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
    public class CreateAskedQuestionCommandHandler:IRequestHandler<CreateAskedQuestionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AskedQuestion> _repository;

        public CreateAskedQuestionCommandHandler(IMapper mapper, IRepository<AskedQuestion> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(CreateAskedQuestionCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<AskedQuestion>(request);
            await _repository.CreateAsync(value);
        }
    }
}
