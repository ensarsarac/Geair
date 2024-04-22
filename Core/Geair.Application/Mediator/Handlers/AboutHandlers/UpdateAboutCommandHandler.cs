using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.AboutCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IMapper mapper, IRepository<About> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AboutId);
            value.Description1 = request.Description1;
            value.Description2 = request.Description2;
            value.Description3 = request.Description3;
            value.Title=request.Title;
            value.ImageUrl1= request.ImageUrl1;
            value.ImageUrl2= request.ImageUrl2;
            value.Description= request.Description;
            await _repository.UpdateAsync(value);
        }
    }
}
