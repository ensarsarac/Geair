using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.AircraftDtos;

namespace Geair.WebUI.Areas.Admin.Validation.AircraftValidations
{
    public class CreateAircraftDtoValidator:AbstractValidator<CreateAircraftDto>
    {
        public CreateAircraftDtoValidator()
        {
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model boş bırakılamaz.");
            RuleFor(x => x.Capacity).NotEmpty().WithMessage("Kapasite boş bırakılamaz.");
            RuleFor(x => x.BaggageWeight).NotEmpty().WithMessage("Bagaj kapasitesi boş bırakılamaz.");
        }
    }
}
