using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Handlers.Commands
{
    public class UpdateHardwareTypeRequestHandler
        : GenericUpdateRequestHandler<IUnitOfWork, IHardwareTypeRepository, UpdateHardwareTypeDto, HardwareType, UpdateHardwareTypeDtoValidator>
    {
        public UpdateHardwareTypeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IHardwareTypeRepository repository, UpdateHardwareTypeDtoValidator validator)
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
