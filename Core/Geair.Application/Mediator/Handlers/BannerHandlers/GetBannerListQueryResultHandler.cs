using AutoMapper;
using Geair.Application.Interfaces;
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
    public class GetBannerListQueryResultHandler : IRequestHandler<GetBannerListQueryResult, List<GetBannerListQueryResult>>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;
        public GetBannerListQueryResultHandler(IRepository<Banner> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<List<GetBannerListQueryResult>> Handle(GetBannerListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetBannerListQueryResult>>(values);
            return result;
        }
    }
}
