using FluentValidation;
using Geair.Application.Mediator.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Validation.UserValidator
{
	public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
	{
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Numarası boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar boş bırakılamaz.");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim en az 3 karakter olmalıdır.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyisim en az 3 karakter olmalıdır.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email formatında giriş yapınız.");
        }
    }
}
