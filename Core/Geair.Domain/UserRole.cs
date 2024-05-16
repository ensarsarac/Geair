using Geair.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Domain
{
	public class UserRole
	{
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public List<User> Users{ get; set; }
    }
}
