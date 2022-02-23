using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs.Validators
{
    public class GenericHardwareTypeDtoValidator: AbstractValidator<IHardwareTypeDto>
    {
        private readonly IHardwareTypeRepository hardwareTypeRepository;

        public GenericHardwareTypeDtoValidator(IHardwareTypeRepository hardwareTypeRepository)
        {
            this.hardwareTypeRepository = hardwareTypeRepository;
            RuleFor(ht => ht.Name).NotEmpty().NotNull().WithMessage("The Hardware type name cannot be blank.");
        }
    }
}
