using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.TravelDtos;

namespace Geair.WebUI.Areas.Admin.Validation.TravelValidations
{
    public class UpdateTravelDtoValidator:AbstractValidator<UpdateTravelDto>
    {
        public UpdateTravelDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.FromWhere).NotEmpty().WithMessage("Uçak kalkış yeri boş bırakılamaz.");
            RuleFor(x => x.ToWhere).NotEmpty().WithMessage("Uçak iniş yeri boş bırakılamaz.");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Uçak kalkış tarihi boş bırakılamaz.");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Uçak iniş tarihi boş bırakılamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş bırakılamaz.");
            RuleFor(x => x.CoverImageUrl).NotEmpty().WithMessage("Görsel boş bırakılamaz.");
            RuleFor(x => x.Capacity).NotEmpty().WithMessage("Kapasite boş bırakılamaz.");
        }
    }
}
