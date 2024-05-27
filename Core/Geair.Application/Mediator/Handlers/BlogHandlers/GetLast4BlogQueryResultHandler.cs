using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.BlogResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.BlogHandlers
{
    public class GetLast4BlogQueryResultHandler : IRequestHandler<GetLast4BlogQueryResult, List<GetLast4BlogQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast4BlogQueryResultHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast4BlogQueryResult>> Handle(GetLast4BlogQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogListHome();
            var result = values.Select(x => new GetLast4BlogQueryResult
            {
                UserName = x.User.Name+" "+x.User.Surname,
                BlogId=x.BlogId,
                CoverImageUrl=x.CoverImageUrl,
                Date=x.Date,
                Title=x.Title,
            }).ToList();
            return result;
        }
    }
}
