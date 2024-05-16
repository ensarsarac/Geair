using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.AskedQuestionCommands
{
    public class RemoveAskedQuestionCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveAskedQuestionCommand(int id)
        {
            Id = id;
        }
    }
}
