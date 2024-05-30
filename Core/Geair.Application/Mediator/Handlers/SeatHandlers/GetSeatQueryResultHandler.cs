using AutoMapper;
using Geair.Application.Interfaces;
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
    public class GetSeatQueryResultHandler : IRequestHandler<GetSeatQueryResult, List<GetSeatQueryResult>>
    {
        private readonly IRepository<Seat> _repository;
        private readonly IMapper _mapper;
        public GetSeatQueryResultHandler(IRepository<Seat> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSeatQueryResult>> Handle(GetSeatQueryResult request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetSeatQueryResult>>(values);
            return result;
        }
    }
}
