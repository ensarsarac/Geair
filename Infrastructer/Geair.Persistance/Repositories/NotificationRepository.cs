using Geair.Application.Interfaces;
using Geair.Domain.Entities;
using Geair.Persistance.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Persistance.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly Context _context;

        public NotificationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetAllNotification()
        {
            var values = await _context.Notifications.OrderByDescending(x => x.NotificationId).ToListAsync();
            return values;
        }

        public async Task<List<Notification>> GetLast5Notification()
        {
            var values = await _context.Notifications.OrderByDescending(x => x.NotificationId).Take(5).ToListAsync();
            return values;
        }
    }
}
