using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs.Validators;
using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Domain.AssetInventoryEntities;


namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Handlers.Commands
{
    public class UpdateHardwareRequestHandler : GenericUpdateRequestHandler<IUnitOfWork, IHardwareRepository, UpdateHardwareDto, Hardware, UpdateHardwareDtoValidator>
    {
        public UpdateHardwareRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, 
            IHardwareRepository repository, UpdateHardwareDtoValidator validator)
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
