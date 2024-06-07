using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.TicketDtos;

namespace Geair.WebUI.Areas.Admin.Validation.TicketValidations
{
    public class UpdateTicketDtoValidatior:AbstractValidator<UpdateTicketDto>
    {
        public UpdateTicketDtoValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
        }
    }
}