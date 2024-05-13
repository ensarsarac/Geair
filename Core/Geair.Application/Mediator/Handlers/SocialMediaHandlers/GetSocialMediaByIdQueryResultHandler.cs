using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.SocialMediaQueries;
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
    public class GetSocialMediaByIdQueryResultHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;
        public GetSocialMediaByIdQueryResultHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetSocialMediaByIdQueryResult>(value);
            return result;
        }
    }
}
