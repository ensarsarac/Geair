using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.NewsletterDtos;

namespace Geair.WebUI.Areas.Admin.Validation.NewsletterValidations;

public class UpdateNewsletterDtoValidator : AbstractValidator<UpdateNewsletterDto>
{
    public UpdateNewsletterDtoValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi alanı boş geçilemez.");
    }
}
