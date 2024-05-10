using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.FlightOptionsDtos;

namespace Geair.WebUI.Areas.Admin.Validation.FlightOptionsValidations
{
    public class CreateFlightOptionsDtoValidator:AbstractValidator<CreateFlightOptionsDto>
    {
        public CreateFlightOptionsDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Description1).NotEmpty().WithMessage("1. Açıklama boş bırakılamaz.");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("2. Açıklama boş bırakılamaz.");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("3. Açıklama boş bırakılamaz.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Ikon boş bırakılamaz.");
        }
    }
}
