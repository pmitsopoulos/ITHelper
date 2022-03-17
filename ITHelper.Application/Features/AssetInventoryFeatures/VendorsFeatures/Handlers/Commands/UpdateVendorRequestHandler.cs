

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Handlers.Commands
{
    public class UpdateVendorRequestHandler : GenericUpdateRequestHandler<IUnitOfWork, IVendorRepository, UpdateVendorDto, Vendor, UpdateVendorDtoValidator>
    {
        public UpdateVendorRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, 
            IVendorRepository repository, UpdateVendorDtoValidator validator)
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
