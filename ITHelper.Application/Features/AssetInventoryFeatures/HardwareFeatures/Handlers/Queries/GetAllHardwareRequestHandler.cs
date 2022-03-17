using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Handlers.Queries
{
    public class GetAllHardwareRequestHandler : GenericGetAllRequestHandler<IHardwareRepository, HardwareDto, Hardware>
    {
        public GetAllHardwareRequestHandler(IHardwareRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
