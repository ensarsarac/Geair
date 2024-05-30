using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.AircraftDtos;

namespace Geair.WebUI.Areas.Admin.Validation.AircraftValidations
{
    public class CreateAircraftSeatsDtoValidator:AbstractValidator<CreateAircraftSeatsDto>
    {
        public CreateAircraftSeatsDtoValidator()
        {
            RuleFor(x => x.SeatNumber).NotEmpty().WithMessage("Numara boş bırakılamaz.");
            RuleFor(x => x.SeatClass).NotEmpty().WithMessage("Sınıf boş bırakılamaz.");
        }
    }
}
