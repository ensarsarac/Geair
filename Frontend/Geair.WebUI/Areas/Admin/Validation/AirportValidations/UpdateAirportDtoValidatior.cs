using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.AirportDtos;

namespace Geair.WebUI.Areas.Admin.Validation.AirportValidations
{
    public class UpdateAirportDtoValidatior:AbstractValidator<UpdateAirportDto>
    {
        public UpdateAirportDtoValidatior()
        {
            RuleFor(x => x.AirportTitle).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş bırakılamaz.");
        }
    }
}
