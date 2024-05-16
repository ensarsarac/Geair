using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.NewsletterQueries;
using Geair.Application.Mediator.Results.NewsletterResults;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Handlers.NewsletterHandlers;
public class GetNewsletterByIdQueryResultHandler : IRequestHandler<GetNewsletterByIdQuery, GetNewsletterByIdQueryResult>
{
    private readonly IRepository<Newsletter> _newsletterRepository;
    private readonly IMapper _mapper;

    public GetNewsletterByIdQueryResultHandler(IRepository<Newsletter> newsletterRepository, IMapper mapper)
    {
        _newsletterRepository = newsletterRepository;
        _mapper = mapper;
    }
    public async Task<GetNewsletterByIdQueryResult> Handle(GetNewsletterByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _newsletterRepository.GetByIdAsync(request.Id);
        var result = _mapper.Map<GetNewsletterByIdQueryResult>(value);
        return result;
    }
}
