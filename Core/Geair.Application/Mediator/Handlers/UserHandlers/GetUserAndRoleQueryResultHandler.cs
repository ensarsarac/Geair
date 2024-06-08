using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.UserQueries;
using Geair.Application.Mediator.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.UserHandlers
{
    public class GetUserAndRoleQueryResultHandler : IRequestHandler<GetUserAndRoleQuery, GetUserAndRoleQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUserAndRoleQueryResultHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserAndRoleQueryResult> Handle(GetUserAndRoleQuery request, CancellationToken cancellationToken)
        {
            var value = await _userRepository.GetUserAndRole(request.Id);
            return new GetUserAndRoleQueryResult
            {
                RoleName=value.RoleName,
                Id=value.Id,
                Surname=value.Surname,
                Name=value.Name,
            };
        }
    }
}
