using AutoMapper;
using Geair.Application.Interfaces;
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
    public class GetUserQueryResultHandler : IRequestHandler<GetUserQueryResult, List<GetUserQueryResult>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserQueryResultHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetUserList();
            var result = values.Select(x => new GetUserQueryResult
            {
                Email = x.Email,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Phone = x.Phone,
                Surname = x.Surname,
                UserId = x.UserId,
                RoleName = x.Role.RoleName,
            }).ToList();
            return result;
        }
    }
}
