using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.CategoryCommands
{
    public class UpdateCategoryCommand:IRequest
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
