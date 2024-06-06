using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.RoleResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.RoleHandlers
{
    public class GetRoleQueryResultHandler : IRequestHandler<GetRoleQueryResult, List<GetRoleQueryResult>>
    {
        private readonly IRepository<Role> _repository;
        private readonly IMapper _mapper;

        public GetRoleQueryResultHandler(IRepository<Role> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetRoleQueryResult>> Handle(GetRoleQueryResult request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetAllListAsync();
            return _mapper.Map<List<GetRoleQueryResult>>(values);

        }
    }
}
