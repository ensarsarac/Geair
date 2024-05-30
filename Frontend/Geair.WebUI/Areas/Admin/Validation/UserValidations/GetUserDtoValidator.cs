using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.UserDtos;

namespace Geair.WebUI.Areas.Admin.Validation.UserValidations
{
    public class GetUserDtoValidator:AbstractValidator<GetUserDto>
    {
        public GetUserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.");
        }
    }
}
