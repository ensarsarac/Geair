using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.TicketResults;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Handlers.TicketHandlers
{
    public class GetTicketQueryResultHandler : IRequestHandler<GetTicketQueryResult, List<GetTicketQueryResult>>
    {
        private readonly IRepository<Ticket> _repository;
        private readonly IMapper _mapper;

        public GetTicketQueryResultHandler(IRepository<Ticket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTicketQueryResult>> Handle(GetTicketQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetTicketQueryResult>>(values);
            return result;
        }
    }
}