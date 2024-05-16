using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.NewsletterQueries;
using Geair.Application.Mediator.Results.NewsletterResults;
using Geair.Application.Mediator.Results.SocialMediaResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.NewsletterHandlers;
public class GetNewsletterQueryResultHandler : IRequestHandler<GetNewsletterQuery, List<GetNewsletterQueryResult>>
{
    private readonly IRepository<Newsletter> _repository;
    private readonly IMapper _mapper;
    public GetNewsletterQueryResultHandler(IRepository<Newsletter> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<GetNewsletterQueryResult>> Handle(GetNewsletterQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllListAsync();
        var result = _mapper.Map<List<GetNewsletterQueryResult>>(values);
        return result;
    }
}
