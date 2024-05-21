using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.BlogCommands;
using Geair.Application.ViewModels;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    { 
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IMapper mapper, IRepository<Blog> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            //request.UserId = _userService.GetUserId();
            var result = _mapper.Map<Blog>(request);
            await _repository.CreateAsync(result);
        }
    }
}
