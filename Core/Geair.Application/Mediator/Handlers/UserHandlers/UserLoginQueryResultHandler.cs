using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.UserQueries;
using Geair.Application.Mediator.Results.UserResults;
using Geair.Application.Tools;
using Geair.Domain;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.UserHandlers
{
    public class UserLoginQueryResultHandler : IRequestHandler<UserLoginQuery,UserLoginQueryResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserLoginQueryResultHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserLoginQueryResult> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var value = new UserLoginQueryResult();
            var user = await _userRepository.GetUserByEmailAsync(x=>x.Email==request.Email && x.Password==request.Password);

            if(user == null)
            {
                value.IsExist = false;
            }
            else
            {
                value.IsExist = true;
                value.NameSurname = user.Name + " " + user.Surname;
                value.Role = user.Role.RoleName;
                value.Id = user.UserId;
                value.Email = user.Email;
            }
            return value;
        }
    }
}
