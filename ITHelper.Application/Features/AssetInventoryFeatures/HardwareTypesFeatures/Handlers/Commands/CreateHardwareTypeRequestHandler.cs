using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Handlers.Commands
{
    public class CreateHardwareTypeRequestHandler : GenericCreateRequestHandler<IUnitOfWork, CreateHardwareTypeDto, HardwareType, IHardwareTypeRepository, CreateHardwareTypeDtoValidator>
    {
        public CreateHardwareTypeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IHardwareTypeRepository repository, CreateHardwareTypeDtoValidator validator) 
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
