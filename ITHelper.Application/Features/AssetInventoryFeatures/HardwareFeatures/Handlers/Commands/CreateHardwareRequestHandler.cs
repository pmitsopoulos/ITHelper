using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs.Validators;

using ITHelper.Application.Features.CommonFeatures.Handlers.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Handlers.Commands
{
    public class CreateHardwareRequestHandler : GenericCreateRequestHandler<IUnitOfWork, CreateHardwareDto, Hardware, IHardwareRepository, CreateHardwareDtoValidator>
    {
        public CreateHardwareRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, 
            IHardwareRepository repository, CreateHardwareDtoValidator validator)
            : base(unitOfWork, mapper, repository, validator)
        {
        }
    }
}
