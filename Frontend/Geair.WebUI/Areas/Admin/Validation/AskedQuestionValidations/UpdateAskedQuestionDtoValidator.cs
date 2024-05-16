using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.AskedQuestionDtos;

namespace Geair.WebUI.Areas.Admin.Validation.AskedQuestionValidations
{
    public class UpdateAskedQuestionDtoValidator:AbstractValidator<UpdateAskedQuestionDto>
    {
        public UpdateAskedQuestionDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık bilgisi boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama bilgisi boş bırakılamaz.");
        }
    }
}
