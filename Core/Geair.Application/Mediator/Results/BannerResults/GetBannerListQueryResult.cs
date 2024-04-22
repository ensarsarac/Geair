using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.BannerResults
{
    public class GetBannerListQueryResult:IRequest<List<GetBannerListQueryResult>>
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
