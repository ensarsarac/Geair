using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.FeatureCommands
{
    public class UpdateFeatureCommand:IRequest
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
