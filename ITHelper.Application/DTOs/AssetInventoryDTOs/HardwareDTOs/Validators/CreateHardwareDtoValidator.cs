using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs.Validators
{
    public class CreateHardwareDtoValidator : AbstractValidator<CreateHardwareDto>
    {
        private readonly IHardwareRepository hardwareRepository;

        public CreateHardwareDtoValidator(IHardwareRepository hardwareRepository)
        {
            this.hardwareRepository = hardwareRepository;
            Include(new GenericHardwareDtoValidator(this.hardwareRepository));
            RuleFor(h => h.DiscontinueDate).GreaterThan(h => h.InitializationDate).WithMessage("The discontinue date cannot be earlier than the initialization date.");
        }
    }
}
