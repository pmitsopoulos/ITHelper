using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;


namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Handlers.Commands
{
    public class DeleteHardwareRequestHandler : GenericDeleteRequestHandler<IUnitOfWork, IHardwareRepository, Hardware>
    {
        public DeleteHardwareRequestHandler(IUnitOfWork genericUnitOfWork, IMapper mapper, IHardwareRepository repository)
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }
}
