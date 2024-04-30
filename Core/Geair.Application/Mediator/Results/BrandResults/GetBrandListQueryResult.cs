using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.BrandResults
{
    public class GetBrandListQueryResult:IRequest<List<GetBrandListQueryResult>>
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Logo { get; set; }
    }
}
