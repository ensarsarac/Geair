using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.AboutDtos;

namespace Geair.WebUI.Areas.Admin.Validation.AboutValidations
{
    public class UpdateAboutDtoValidatior:AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutDtoValidatior()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama 1 boş bırakılamaz.");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama 2 boş bırakılamaz.");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama 3 boş bırakılamaz.");
            RuleFor(x => x.ImageUrl1).NotEmpty().WithMessage("1. Görsel boş bırakılamaz.");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("2. Görsel boş bırakılamaz.");
        }
    }
}
