using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.CategoryDtos;

namespace Geair.WebUI.Areas.Admin.Validation.CategoryValidations
{
    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı boş bırakılamaz.");
        }
    }
}
