using Geair.Application.Interfaces;
using Geair.Application.ViewModels;
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

        public async Task<GetUserAndRoleViewModel> GetUserAndRole(int id)
        {
            var value = await _context.Users.Where(x => x.UserId == id).Include(x => x.Role).Select(x => new { x.Role.RoleName, x.RoleId,x.Name,x.Surname }).FirstOrDefaultAsync();
            return new GetUserAndRoleViewModel { RoleName=value.RoleName,Id=value.RoleId,Name=value.Name,Surname=value.Surname};
        }

        public async Task<User> GetUserByEmailAsync(Expression<Func<User, bool>> filter)
        {
            var value = await _context.Users.Where(filter).Include(x=>x.Role).FirstOrDefaultAsync();
            return value;
        }

        public async Task<List<User>> GetUserList()
        {
            var value = await _context.Users.Include(x => x.Role).ToListAsync();
            return value;
        }

		public async Task UpdateUserRole(int userId,int roleId)
		{
            var value = await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            value.RoleId = roleId;
            await _context.SaveChangesAsync();
		}
	}
}
