using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.NewsletterCommands;
using Geair.Application.Mediator.Commands.SocialMediaCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.NewsletterHandlers;
public class CreateNewsletterCommandHandler : IRequestHandler<CreateNewsletterCommand>
{
    private readonly IRepository<Newsletter> _newsletterRepository;
    private readonly IMapper _mapper;
    public CreateNewsletterCommandHandler(IRepository<Newsletter> newsletterRepository, IMapper mapper)
    {
        _newsletterRepository = newsletterRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateNewsletterCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Newsletter>(request);
        await _newsletterRepository.CreateAsync(result);
    }
}
