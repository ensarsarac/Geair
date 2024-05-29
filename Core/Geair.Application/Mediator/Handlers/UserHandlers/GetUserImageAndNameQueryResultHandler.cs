using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.UserQueries;
using Geair.Application.Mediator.Results.UserResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.UserHandlers
{
    public class GetUserImageAndNameQueryResultHandler : IRequestHandler<GetUserImageAndNameQuery, GetUserImageAndNameQueryResult>
    {
        private readonly IRepository<User> _repository;

        public GetUserImageAndNameQueryResultHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserImageAndNameQueryResult> Handle(GetUserImageAndNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return new GetUserImageAndNameQueryResult
            {
                ImageUrl=user.ImageUrl,
                NameSurname=user.Name+" "+user.Surname,
            };
        }
    }
}
