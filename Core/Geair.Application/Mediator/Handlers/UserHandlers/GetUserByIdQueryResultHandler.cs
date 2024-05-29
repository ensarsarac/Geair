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
    public class GetUserByIdQueryResultHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryResultHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return new GetUserByIdQueryResult
            {
                Email = user.Email,
                ImageStorageName = user.ImageStorageName,
                ImageUrl = user.ImageUrl,
                Name = user.Name,
                Phone= user.Phone,
                Surname = user.Surname,
                UserId=user.UserId,
                ImageFile=user.ImageFile,
            };
        }
    }
}
