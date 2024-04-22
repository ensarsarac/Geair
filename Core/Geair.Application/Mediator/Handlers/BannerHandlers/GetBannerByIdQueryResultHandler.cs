using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.BannerQueries;
using Geair.Application.Mediator.Results.AboutResults;
using Geair.Application.Mediator.Results.BannerResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryResultHandler : IRequestHandler<GetBannerByIdQuery, GetBannerByIdQueryResult>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;
        public GetBannerByIdQueryResultHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetBannerByIdQueryResult>(values);
            return result;
        }
    }
}
