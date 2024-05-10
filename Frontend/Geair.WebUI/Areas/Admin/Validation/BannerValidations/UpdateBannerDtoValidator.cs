using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.BannersDtos;

namespace Geair.WebUI.Areas.Admin.Validation.BannerValidations
{
    public class UpdateBannerDtoValidator:AbstractValidator<UpdateBannerDto>
    {
        public UpdateBannerDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş bırakılamaz");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Lütfen en az 50 karakter veri girişi yapınız");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter veri girişi yapınız");
        }
    }
}
