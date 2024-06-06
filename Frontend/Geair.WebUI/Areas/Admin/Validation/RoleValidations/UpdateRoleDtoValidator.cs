using FluentValidation;
using Geair.WebUI.Areas.Admin.Dtos.RoleDtos;

namespace Geair.WebUI.Areas.Admin.Validation.RoleValidations
{
    public class UpdateRoleDtoValidator:AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleDtoValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol adı boş bırakılamaz.");
        }
    }
}
