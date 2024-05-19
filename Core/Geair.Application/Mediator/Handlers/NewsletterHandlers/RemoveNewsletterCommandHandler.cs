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
public class RemoveNewsletterCommandHandler : IRequestHandler<RemoveNewsletterCommand>
{
    private readonly IRepository<Newsletter> _repository;
    public RemoveNewsletterCommandHandler(IRepository<Newsletter> repository)
    {
        _repository = repository;
    }
    public async Task Handle(RemoveNewsletterCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
    }
}
