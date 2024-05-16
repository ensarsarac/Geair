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
public class UpdateNewsletterCommandHandler : IRequestHandler<UpdateNewsletterCommand>
{
    private readonly IRepository<Newsletter> _newsletterRepository;
    private readonly IMapper _mapper;
    public UpdateNewsletterCommandHandler(IRepository<Newsletter> newsletterRepository, IMapper mapper)
    {
        _newsletterRepository = newsletterRepository;
        _mapper = mapper;
    }
    
    public async Task Handle(UpdateNewsletterCommand request, CancellationToken cancellationToken)
    {
        var value = await _newsletterRepository.GetByIdAsync(request.NewsletterId);
        value.Email = request.Email;
        await _newsletterRepository.UpdateAsync(value);
    }
}
