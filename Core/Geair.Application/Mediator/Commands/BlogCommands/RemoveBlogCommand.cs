using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveBlogCommand(int id)
        {
            Id = id;
        }
    }
}
