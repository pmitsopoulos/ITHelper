using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs.Validators
{
    public class AssignHardwareDtoValidator : AbstractValidator<AssignHardwareDto>
    {
        private readonly IHardwareRepository hardwareRepository;

        public AssignHardwareDtoValidator(IHardwareRepository hardwareRepository)
        {
            this.hardwareRepository = hardwareRepository;
            
            RuleFor(h => h.SiteId)
                .NotEqual(default(int))
                .When(h1 => h1.DepartmentId != default)
                .WithMessage("A site must be selected to assign an asset to a department.");

            RuleFor(h => h.DepartmentId)
                .NotEqual(default(int))
                .When(h1 => h1.SiteId != default)
                .WithMessage("A department must be selected to assign this asset to your selected site.");

            RuleFor(h => h.SiteId)
                .Equal(default(int))
                .When(h1 => h1.UserId != default)
                .WithMessage("To assign an asset to a user the department and site selections must be blank");

            RuleFor(h => h.DepartmentId)
               .Equal(default(int))
                .When(h1 => h1.UserId != default)
                .WithMessage("To assign an asset to a user the department and site selections must be blank");
        }
    }
}
