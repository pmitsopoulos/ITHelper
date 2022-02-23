using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs.Validators
{
    public  class UpdateVendorDtoValidator : AbstractValidator<UpdateVendorDto>
    {
        private readonly IVendorRepository vendorRepository;

        public UpdateVendorDtoValidator(IVendorRepository vendorRepository)
        {
            this.vendorRepository = vendorRepository;
            Include(new GenericVendorDtoValidator(this.vendorRepository));
        }
    }
}
