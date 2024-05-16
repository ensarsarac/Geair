using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.NewsletterCommands;
public class CreateNewsletterCommand : IRequest
{
    public string Email { get; set; }
}
