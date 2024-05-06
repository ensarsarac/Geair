using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.CompanyAddressQueries;
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
    public class GetCompanyAddressByIdQueryResultHandler : IRequestHandler<GetCompanyAddressByIdQuery, GetCompanyAddressByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyAddress> _repository;

        public GetCompanyAddressByIdQueryResultHandler(IMapper mapper, IRepository<CompanyAddress> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<GetCompanyAddressByIdQueryResult> Handle(GetCompanyAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetCompanyAddressByIdQueryResult>(value);
            return result;
        }
    }
}
