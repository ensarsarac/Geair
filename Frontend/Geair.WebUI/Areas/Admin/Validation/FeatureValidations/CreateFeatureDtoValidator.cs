using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.FeatureDtos;

namespace Geair.WebUI.Areas.Admin.Validation.FeatureValidations
{
    public class CreateFeatureDtoValidator:AbstractValidator<CreateFeatureDto>
    {
        public CreateFeatureDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon boş bırakılamaz.");
        }
    }
}
