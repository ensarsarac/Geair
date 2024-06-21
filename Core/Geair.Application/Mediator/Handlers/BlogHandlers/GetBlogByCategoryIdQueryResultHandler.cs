using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.BlogQueries;
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
    public class GetBlogByCategoryIdQueryResultHandler : IRequestHandler<GetBlogByCategoryIdQuery, List<GetBlogByCategoryIdQueryResult>>
    {
        private readonly IBlogRepository _repository;
        public GetBlogByCategoryIdQueryResultHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<GetBlogByCategoryIdQueryResult>> Handle(GetBlogByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogByCategoryIdListHome(request.Id);
            var result = values.Select(x => new GetBlogByCategoryIdQueryResult
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
