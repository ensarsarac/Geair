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
        private readonly ITicketRepository _repository;
        private readonly IMapper _mapper;

        public GetTicketQueryResultHandler(ITicketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTicketQueryResult>> Handle(GetTicketQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetTicketListWithInclude();
            var list = values.Select(x => new GetTicketQueryResult
            {
                ArrivalTime = x.Flight.ArrivalTime,
                BirthDate = x.BirthDate,
                DepartureTime = x.Flight.DepartureTime,
                Email = x.Email,
                FlightId = x.Flight.FlightId,
                FlightTitle = x.Flight.DepartureAirport.AirportTitle + " - " + x.Flight.ArrivalAirport.AirportTitle,
                FlyNumber = x.Flight.FlightNumber,
                Gender = x.Gender,
                Name = x.Name,
                PersonCount = x.PersonCount,
                Phone = x.Phone,
                Surname = x.Surname,
                Status = x.Status,
                TicketId = x.TicketId,
                TicketType = x.TicketType,
                UserId = x.UserId,
                FlightPrice = x.TicketType =="Business" ? x.Flight.BusinessPrice : x.Flight.EconomyPrice,
                TotalPrice = x.TotalPrice,

            }).ToList();
           
            return list;
        }
    }
}