

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Handlers.Commands
{
    public class CreateVendorRequestHandler : GenericCreateRequestHandler<IUnitOfWork, CreateVendorDto, Vendor, IVendorRepository, CreateVendorDtoValidator>
    {
        public CreateVendorRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IVendorRepository repository, CreateVendorDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
