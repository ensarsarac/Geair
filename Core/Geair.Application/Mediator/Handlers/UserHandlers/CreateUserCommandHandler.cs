﻿using AutoMapper;
using FluentValidation.Results;
using Geair.Application.Enums;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.UserCommands;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.UserHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                Phone = request.Phone,
                Surname = request.Surname,
                UserRoleId=(int)Roles.member,
            });
        }
    }
}
