using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.AboutResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AboutHandlers
{
    public class GetAboutListQueryResultHandler : IRequestHandler<GetAboutListQueryResult, List<GetAboutListQueryResult>>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutListQueryResultHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAboutListQueryResult>> Handle(GetAboutListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetAboutListQueryResult>>(values);
            return result;
        }
    }
}
