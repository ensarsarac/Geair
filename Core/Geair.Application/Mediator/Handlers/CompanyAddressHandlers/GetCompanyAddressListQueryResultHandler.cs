using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.CompanyAddressResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.CompanyAddressHandlers
{
    public class GetCompanyAddressListQueryResultHandler : IRequestHandler<GetCompanyAddressListQueryResult, List<GetCompanyAddressListQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyAddress> _repository;

        public GetCompanyAddressListQueryResultHandler(IMapper mapper, IRepository<CompanyAddress> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<GetCompanyAddressListQueryResult>> Handle(GetCompanyAddressListQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetCompanyAddressListQueryResult>>(values);
            return result;
        }
    }
}
