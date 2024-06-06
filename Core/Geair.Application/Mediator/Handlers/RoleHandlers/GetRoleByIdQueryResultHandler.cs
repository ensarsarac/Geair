using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.RoleQueries;
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
    public class GetRoleByIdQueryResultHandler:IRequestHandler<GetRoleByIdQuery,GetRoleByIdQueryResult>
    {
        private readonly IRepository<Role> _repository;
        private readonly IMapper _mapper;

        public GetRoleByIdQueryResultHandler(IRepository<Role> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetRoleByIdQueryResult> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetRoleByIdQueryResult>(value);
        }
    }
}
