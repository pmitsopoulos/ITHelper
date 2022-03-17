

using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Handlers.Queries
{
    public class GetHardwareTypeRequestHandler : GenericGetByIdRequestHandler<IHardwareTypeRepository, HardwareTypeDto, HardwareType>
    {
        public GetHardwareTypeRequestHandler(IHardwareTypeRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
