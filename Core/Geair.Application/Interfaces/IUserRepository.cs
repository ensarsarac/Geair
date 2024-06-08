using Geair.Application.ViewModels;
using Geair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetUserByEmailAsync(Expression<Func<User,bool>> filter);
		Task<List<User>> GetUserList();
		Task<GetUserAndRoleViewModel> GetUserAndRole(int id);
		Task UpdateUserRole(int userId,int roleId);

	}
}
