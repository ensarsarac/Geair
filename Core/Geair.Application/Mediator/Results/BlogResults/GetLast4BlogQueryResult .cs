using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Geair.Application.Mediator.Results.BlogResults
{
    public class GetLast4BlogQueryResult:IRequest<List<GetLast4BlogQueryResult>>
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        // public string Description { get; set; }
        // public string Info { get; set; }
        // public string ImageUrl1 { get; set; }
        // public string ImageUrl2 { get; set; }
        public DateTime Date { get; set; }
        // public string CategoryName { get; set; }
        public string UserName { get; set; }
    }
}