using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.UserResults
{
    public class UserLoginQueryResult:IRequest
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
