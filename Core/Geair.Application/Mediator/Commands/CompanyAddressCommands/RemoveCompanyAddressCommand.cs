using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.CompanyAddressCommands
{
    public class RemoveCompanyAddressCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveCompanyAddressCommand(int id)
        {
            Id = id;
        }
    }
}
