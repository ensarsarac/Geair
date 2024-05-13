using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand:IRequest
    {
        public string Platform { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
