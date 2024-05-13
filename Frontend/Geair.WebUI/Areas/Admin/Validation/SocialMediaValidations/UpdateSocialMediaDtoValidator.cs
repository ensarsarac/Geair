using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.SocialMediaDtos;

namespace Geair.WebUI.Areas.Admin.Validation.SocialMediaValidations
{
    public class UpdateSocialMediaDtoValidator:AbstractValidator<UpdateSocialMediaDto>
    {
        public UpdateSocialMediaDtoValidator()
        {
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform adı boş bırakılamaz.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Ikon boş bırakılamaz.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url boş bırakılamaz.");
        }
    }
}
