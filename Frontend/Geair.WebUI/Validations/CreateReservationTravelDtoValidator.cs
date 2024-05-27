using FluentValidation;
using Geair.DTOLayer.ReservationTravelDtos;

namespace Geair.WebUI.Validations
{
	public class CreateReservationTravelDtoValidator:AbstractValidator<CreateReservationTravelDto>
	{
        public CreateReservationTravelDtoValidator()
        {
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı boş geçilemez.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email formatına uygun giriş yapınız.");
        }
    }
}
