using Geair.Application.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.NewsletterResults;
public class GetNewsletterQueryResult 
{
    public int NewsletterId { get; set; }
    public string Email { get; set; }
}
