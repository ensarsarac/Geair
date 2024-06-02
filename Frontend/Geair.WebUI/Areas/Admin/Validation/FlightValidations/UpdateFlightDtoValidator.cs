using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.FlightDtos;

namespace Geair.WebUI.Areas.Admin.Validation.FlightValidations
{
    public class UpdateFlightDtoValidator:AbstractValidator<UpdateFlightDto>
    {
        public UpdateFlightDtoValidator()
        {

            RuleFor(x => x.DepartureAirportId).NotEmpty().WithMessage("Kalkış havaalanı boş bırakılamaz.");
            RuleFor(x => x.ArrivalAirportId).NotEmpty().WithMessage("İniş havaalanı boş bırakılamaz.");
            RuleFor(x => x.DepartureTime).NotEmpty().WithMessage("Kalkış zamanı boş bırakılamaz.");
            RuleFor(x => x.ArrivalTime).NotEmpty().WithMessage("İniş zamanı boş bırakılamaz.");
            RuleFor(x => x.AircraftId).NotEmpty().WithMessage("Uçak boş bırakılamaz.");
            RuleFor(x => x.EconomyPrice).NotEmpty().WithMessage("Ekonomi fiyat boş bırakılamaz.");
            RuleFor(x => x.BusinessPrice).NotEmpty().WithMessage("Business fiyat boş bırakılamaz.");
        }
    }
}
