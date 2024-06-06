using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.RoleDtos;

namespace Geair.WebUI.Areas.Admin.Validation.RoleValidations
{
    public class CreateRoleDtoValidator:AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol adı boş bırakılamaz.");
        }
    }
}
