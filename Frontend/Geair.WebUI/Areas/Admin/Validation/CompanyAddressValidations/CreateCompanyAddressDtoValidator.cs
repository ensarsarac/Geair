using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.CompanyAddressDtos;

namespace Geair.WebUI.Areas.Admin.Validation.CompanyAddressValidations
{
    public class CreateCompanyAddressDtoValidator:AbstractValidator<CreateCompanyAddressDto>
    {
        public CreateCompanyAddressDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres alanı boş bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş bırakılamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email formatında giriş yapınız.");
        }
    }
}
