using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.VendorDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;


namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Handlers.Queries
{
    public class GetVendorBySearchTermRequestHandler
        : GenericGetBySearchTermRequestHandler<IVendorRepository, VendorDto, Vendor>
    {
        public GetVendorBySearchTermRequestHandler(IVendorRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
