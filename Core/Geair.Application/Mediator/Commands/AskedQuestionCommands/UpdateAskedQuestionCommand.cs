using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.AskedQuestionCommands
{
    public class UpdateAskedQuestionCommand:IRequest
    {
        public int AskedQuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RowNumber { get; set; }
    }
}
