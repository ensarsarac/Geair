using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.ReservationTravelDtos;

namespace Geair.WebUI.Areas.Admin.Validation.ReservationTravelValidations
{
    public class UpdateReservationTravelDtoValidator:AbstractValidator<UpdateReservationTravelDto>
    {
        public UpdateReservationTravelDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş bırakılamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş bırakılamaz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş bırakılamaz");
            RuleFor(x => x.TravelId).NotEmpty().WithMessage("Seyahat boş bırakılamaz");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı boş bırakılamaz");
            RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("Toplam fiyat boş bırakılamaz");
        }
    }
}
