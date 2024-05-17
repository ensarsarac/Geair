using FluentValidation;
using Geair.DTOLayer.UserDtos;

namespace Geair.WebUI.Validations
{
    public class RegisterUserDtoValidator:AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 veri girişi yapınız.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş bırakılamaz.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Lütfen en az 3 veri girişi yapınız.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Numarası boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar boş bırakılamaz.");
            RuleFor(x => x.AcceptTerms).Must(y=>y.Equals(true)).WithMessage("Şartları kabul etmelisiniz.");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreler uyuşmuyor.");
        }
    }
}
