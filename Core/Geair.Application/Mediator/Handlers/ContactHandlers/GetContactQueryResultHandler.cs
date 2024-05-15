using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.ContactResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.ContactHandlers
{
    public class GetContactQueryResultHandler : IRequestHandler<GetContactQueryResult, List<GetContactQueryResult>>
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactQueryResultHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetContactQueryResult>> Handle(GetContactQueryResult request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetContactQueryResult>>(values);
            return result;
        }
    }
}
