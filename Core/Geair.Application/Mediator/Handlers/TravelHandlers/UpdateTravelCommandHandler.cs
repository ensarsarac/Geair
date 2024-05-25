using AutoMapper;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.TravelCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.TravelHandlers
{
    public class UpdateTravelCommandHandler : IRequestHandler<UpdateTravelCommand>
    {
        private readonly IRepository<Travel> _repository;

        public UpdateTravelCommandHandler(IRepository<Travel> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTravelCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TravelId);
            value.Title = request.Title;
            value.FromWhere = request.FromWhere;
            value.ToWhere = request.ToWhere;
            value.StartDate = request.StartDate;
            value.EndDate = request.EndDate;
            value.Price = request.Price;
            value.CoverImageUrl= request.CoverImageUrl;
            value.Capacity = request.Capacity;
            value.Status= request.Status;
            value.IsFull= request.IsFull;
            await _repository.UpdateAsync(value);
        }
    }
}
