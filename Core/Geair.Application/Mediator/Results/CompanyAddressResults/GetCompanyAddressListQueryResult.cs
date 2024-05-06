using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Results.CompanyAddressResults
{
    public class GetCompanyAddressListQueryResult:IRequest<List<GetCompanyAddressListQueryResult>>
    {
        public int CompanyAddressId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
