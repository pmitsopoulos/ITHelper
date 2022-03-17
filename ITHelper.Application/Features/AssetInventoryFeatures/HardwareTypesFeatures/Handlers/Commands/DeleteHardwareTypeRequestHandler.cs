

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Handlers.Commands
{
    public class DeleteHardwareTypeRequestHandler
        : GenericDeleteRequestHandler<IUnitOfWork, IHardwareTypeRepository, HardwareType>
    {
        public DeleteHardwareTypeRequestHandler(IUnitOfWork genericUnitOfWork, IMapper mapper, IHardwareTypeRepository repository)
            : base(genericUnitOfWork, mapper, repository)
        {
        }
    }
}
