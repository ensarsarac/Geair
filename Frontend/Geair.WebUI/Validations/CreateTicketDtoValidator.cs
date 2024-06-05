using FluentValidation;
using Geair.DTOLayer.TicketDtos;

namespace Geair.WebUI.Validations
{
    public class CreateTicketDtoValidator:AbstractValidator<CreateTicketDto>
    {
        public CreateTicketDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı boş bırakılamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş bırakılamaz.");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Cinsiyet boş bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz.");
            RuleFor(x => x.TicketType).NotEmpty().WithMessage("Bilet tipi boş bırakılamaz.");
            RuleFor(x => x.AcceptTerms).NotEmpty().WithMessage("Sözleşme kabul etmelisiniz.");

        }
    }
}
