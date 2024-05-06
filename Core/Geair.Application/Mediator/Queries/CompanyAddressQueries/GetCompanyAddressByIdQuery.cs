using Geair.Application.Mediator.Results.CompanyAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Queries.CompanyAddressQueries
{
    public class GetCompanyAddressByIdQuery:IRequest<GetCompanyAddressByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCompanyAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
