using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Handlers.Commands
{
    public class DeleteVendorRequestHandler : GenericDeleteRequestHandler<IUnitOfWork, IVendorRepository, Vendor>
    {
        public DeleteVendorRequestHandler(IUnitOfWork genericUnitOfWork, IMapper mapper, IVendorRepository repository)
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }
}
