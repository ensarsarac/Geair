using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.BlogDtos;

namespace Geair.WebUI.Areas.Admin.Validation.BlogsValidations
{
    public class UpdateBlogDtoValidator:AbstractValidator<UpdateBlogDto>
    {
        public UpdateBlogDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.CoverImageUrl).NotEmpty().WithMessage("Büyük resim boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.Info).NotEmpty().WithMessage("Bilgilendirme boş bırakılamaz.");
            RuleFor(x => x.ImageUrl1).NotEmpty().WithMessage("1. Görsel boş bırakılamaz.");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("2. Görsel boş bırakılamaz.");
        }
    }
}
