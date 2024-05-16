using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.NewsletterCommands;
public class RemoveNewsletterCommand : IRequest
{
    public int Id { get; set; }

    public RemoveNewsletterCommand(int id)
    {
        Id = id;
    }
}
