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
    public class GetBlogByIdQueryResultHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByIdQueryResultHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBlogByIdWithUserAndCategoryByOrder(request.Id);
            var result = new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
                CategoryName=value.Category.CategoryName,
                CategoryId=value.Category.CategoryId,
                CoverImageUrl=value.CoverImageUrl,
                Date=value.Date,
                Description=value.Description,
                ImageUrl1 = value.ImageUrl1,
                ImageUrl2 = value.ImageUrl2,
                Info=value.Info,
                Title=value.Title,
                UserName=value.User.Name+" "+value.User.Surname,
            };
            return result;
        }
    }
}
