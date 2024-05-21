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
    public class GetBlogQueryResultHandler : IRequestHandler<GetBlogQueryResult, List<GetBlogQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogQueryResultHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogListWithUserAndCategoryByOrder();
            var result = values.Select(x => new GetBlogQueryResult
            {
                UserName = x.User.Name+" "+x.User.Surname,
                BlogId=x.BlogId,
                CategoryName=x.Category.CategoryName,
                CoverImageUrl=x.CoverImageUrl,
                Date=x.Date,
                Description=x.Description,
                ImageUrl1 = x.ImageUrl1,
                ImageUrl2 = x.ImageUrl2,
                Info=x.Info,
                Title=x.Title,
            }).ToList();
            return result;
        }
    }
}
