using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.AircraftDtos;

namespace Geair.WebUI.Areas.Admin.Validation.AircraftValidations
{
    public class UpdateAircraftSeatsDtoValidator:AbstractValidator<UpdateAircraftSeatsDto>
    {
        public UpdateAircraftSeatsDtoValidator()
        {
            RuleFor(x => x.SeatNumber).NotEmpty().WithMessage("Numara boş bırakılamaz.");
            RuleFor(x => x.SeatClass).NotEmpty().WithMessage("Sınıf boş bırakılamaz.");
        }
    }
}
