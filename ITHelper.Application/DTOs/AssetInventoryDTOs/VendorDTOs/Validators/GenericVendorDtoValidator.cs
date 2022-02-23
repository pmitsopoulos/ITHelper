using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs.Validators
{
    public class GenericVendorDtoValidator : AbstractValidator<IVendorDto>
    {
        private readonly IVendorRepository vendorRepository;

        public GenericVendorDtoValidator(IVendorRepository vendorRepository)
        {
            this.vendorRepository = vendorRepository;
            RuleFor(v=>v.Name).NotEmpty().NotNull().WithMessage("The vendor name is required.");
        }
    }
}
