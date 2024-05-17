using Geair.Application.Interfaces;
using Geair.Domain.Entities;
using Geair.Persistance.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(Expression<Func<User, bool>> filter)
        {
            var value = await _context.Users.Where(filter).Include(x=>x.Role).FirstOrDefaultAsync();
            return value;
        }
    }
}
