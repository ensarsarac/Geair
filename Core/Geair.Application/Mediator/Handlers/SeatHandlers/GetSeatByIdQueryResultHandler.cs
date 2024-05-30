using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Queries.SeatQueries;
using Geair.Application.Mediator.Results.SeatResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.SeatHandlers
{
    public class GetSeatByIdQueryResultHandler : IRequestHandler<GetSeatByIdQuery, GetSeatByIdQueryResult>
    {
        private readonly IRepository<Seat> _repository;
        private readonly IMapper _mapper;
        public GetSeatByIdQueryResultHandler(IRepository<Seat> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetSeatByIdQueryResult> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetSeatByIdQueryResult>(value);
            return result;
        }
    }
}
