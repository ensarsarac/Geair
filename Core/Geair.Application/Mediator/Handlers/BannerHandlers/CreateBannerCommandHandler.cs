using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.BannerCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;
        public CreateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Banner>(request);
            await _repository.CreateAsync(value);
        }
    }
}
