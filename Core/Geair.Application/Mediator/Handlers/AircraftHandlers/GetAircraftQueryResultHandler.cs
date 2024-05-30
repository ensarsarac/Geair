using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Results.AircraftResults;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.AircraftHandlers
{
    public class GetAircraftQueryResultHandler : IRequestHandler<GetAircraftQueryResult, List<GetAircraftQueryResult>>
    {
        private readonly IRepository<Aircraft> _repository;
        private readonly IMapper _mapper;

        public GetAircraftQueryResultHandler(IRepository<Aircraft> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAircraftQueryResult>> Handle(GetAircraftQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllListAsync();
            var result = _mapper.Map<List<GetAircraftQueryResult>>(values);
            return result;
        }
    }
}
