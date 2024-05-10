using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.BrandDtos;

namespace Geair.WebUI.Areas.Admin.Validation.BrandValidations
{
    public class CreateBrandDtoValidator:AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Marka adı boş bırakılamaz.");
            RuleFor(x => x.Logo).NotEmpty().WithMessage("Logo boş bırakılamaz.");
        }
    }
}
