using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Commands.NotificationCommands
{
    public class RemoveNotificationCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveNotificationCommand(int id)
        {
            Id = id;
        }
    }
}
