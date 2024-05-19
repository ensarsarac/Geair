using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.NewsletterDtos;

namespace Geair.WebUI.Areas.Admin.Validation.NewsletterValidations;

public class CreateNewsletterDtoValidator : AbstractValidator<CreateNewsletterDto>
{
    public CreateNewsletterDtoValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi alanı boş geçilemez");
    }
}
