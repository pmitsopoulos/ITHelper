using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs.Validators
{
    public class UpdateHardwareDtoValidator : AbstractValidator<UpdateHardwareDto>
    {
        private readonly IHardwareRepository hardwareRepository;

        public UpdateHardwareDtoValidator(IHardwareRepository hardwareRepository)
        {
            this.hardwareRepository = hardwareRepository;
            Include(new GenericHardwareDtoValidator(this.hardwareRepository));
        }
    }
}
