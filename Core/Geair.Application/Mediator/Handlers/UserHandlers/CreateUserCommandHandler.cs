using AutoMapper;
using FluentValidation.Results;
using Geair.Application.Enums;
using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.UserCommands;
using Geair.Application.Mediator.Results.UserResults;
using Geair.Application.Validation.UserValidator;
using Geair.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.UserHandlers
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, GetUserRegisterQueryResult>
	{
		private readonly IRepository<User> _repository;
		private readonly IMapper _mapper;

		public CreateUserCommandHandler(IRepository<User> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<GetUserRegisterQueryResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
            CreateUserCommandValidator validationRules = new CreateUserCommandValidator();
            ValidationResult result = validationRules.Validate(request);
            if (result.IsValid)
			{
				if(request.Password == request.ConfirmPassword)
                {
					await _repository.CreateAsync(new User
					{
						Email = request.Email,
						Name = request.Name,
						Password = request.Password,
						Phone = request.Phone,
						Surname = request.Surname,
						UserRoleId = (int)Roles.member,
					});
                    var value = new GetUserRegisterQueryResult();
                    value.Result = true;
					value.Error = "Kullanıcı başarıyla kayıt edildi";
                    return value;
                }	
                else
				{
                    var value = new GetUserRegisterQueryResult();
                    value.Result = false;
					value.Error="Şifreler uyuşmuyor";
                    return value;
                }
            }
			else
			{
                var value = new GetUserRegisterQueryResult();
				foreach (var item in result.Errors)
				{
					value.Error+=item.ErrorMessage;
				}
                value.Result = false;
                return value;
            }
		}
	}
}
