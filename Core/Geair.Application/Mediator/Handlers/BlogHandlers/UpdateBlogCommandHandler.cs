using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.BlogCommands;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            value.Title = request.Title;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Description = request.Description;
            value.Info = request.Info;
            value.ImageUrl1 = request.ImageUrl1;
            value.ImageUrl2 = request.ImageUrl2;
            value.Date = request.Date;
            value.CategoryId = request.CategoryId;
            value.UserId = request.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}