using Geair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Interfaces
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetAllNotification();
        Task<List<Notification>> GetLast5Notification();
    }
}
