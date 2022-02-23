using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs.Validators
{
    public class CreateHardwareTypeDtoValidator : AbstractValidator<CreateHardwareTypeDto>
    {
        private readonly IHardwareTypeRepository hardwareTypeRepository;

        public CreateHardwareTypeDtoValidator(IHardwareTypeRepository hardwareTypeRepository)
        {
            this.hardwareTypeRepository = hardwareTypeRepository;
            Include(new GenericHardwareTypeDtoValidator(this.hardwareTypeRepository));
        }
    }
}
