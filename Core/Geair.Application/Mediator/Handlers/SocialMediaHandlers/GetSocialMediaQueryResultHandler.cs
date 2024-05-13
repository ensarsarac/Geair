using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.SocialMediaResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryResultHandler : IRequestHandler<GetSocialMediaQueryResult, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;
        public GetSocialMediaQueryResultHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQueryResult request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetSocialMediaQueryResult>>(values);
            return result;
        }
    }
}
