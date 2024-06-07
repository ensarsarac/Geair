using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.TicketQueries;
using Geair.Application.Mediator.Results.TicketResults;
using Geair.Domain.Entities;
using MediatR;

namespace Geair.Application.Mediator.Handlers.TicketHandlers
{
    public class GetTicketByIdQueryResultHandler : IRequestHandler<GetTicketByIdQuery, GetTicketByIdQueryResult>
    {
        private readonly IRepository<Ticket> _repository;
        private readonly IMapper _mapper;

        public GetTicketByIdQueryResultHandler(IRepository<Ticket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTicketByIdQueryResult> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetTicketByIdQueryResult>(values);
            return result;
        }
    }
}