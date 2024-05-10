using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.BrandDtos;

namespace Geair.WebUI.Areas.Admin.Validation.BrandValidations
{
    public class UpdateBrandDtoValidator:AbstractValidator<UpdateBrandDto>
    {
        public UpdateBrandDtoValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Marka adı boş bırakılamaz.");
            RuleFor(x => x.Logo).NotEmpty().WithMessage("Logo boş bırakılamaz.");
        }
    }
}
