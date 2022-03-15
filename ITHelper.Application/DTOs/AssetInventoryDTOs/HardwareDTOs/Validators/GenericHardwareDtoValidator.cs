using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs.Validators
{
    public class GenericHardwareDtoValidator : AbstractValidator<IHardwareDto>
    {
        private readonly IHardwareRepository hardwareRepository;

        public GenericHardwareDtoValidator(IHardwareRepository hardwareRepository )
        {
            this.hardwareRepository = hardwareRepository;

            RuleFor(h => h.HardwareTypeId)
                .NotEqual(default(int))
                .WithMessage("This asset needs to be registered in a hardware type category.");
            
            RuleFor(h => h.VendorId)
                .NotEqual(default(int))
                .WithMessage("This asset needs to be registered to its' Vendor. If the Vendor name does not exist in the dropdown list please create a new Vendor.");

            RuleFor(h => h.ContactId)
                .NotEqual(default(int))
                .WithMessage("This asset must be assigned to a contact.");

            RuleFor(h => h.Model).NotNull().NotEmpty().WithMessage("The model of the hardware is required.");

            RuleFor(h => h.SerialNumber).NotNull().NotEmpty().WithMessage("The model of the hardware is required.");

            


        }
    }
}
