using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Handlers.Queries
{
    public class GetAllHardwareTypesRequestHandler : GenericGetAllRequestHandler<IHardwareTypeRepository, HardwareTypeDto, HardwareType>
    {
        public GetAllHardwareTypesRequestHandler(IHardwareTypeRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
