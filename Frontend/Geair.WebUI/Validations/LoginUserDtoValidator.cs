using FluentValidation;
using Geair.DTOLayer.UserDtos;

namespace Geair.WebUI.Validations
{
    public class LoginUserDtoValidator:AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email formatında giriş yapınız.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
        }
    }
}
