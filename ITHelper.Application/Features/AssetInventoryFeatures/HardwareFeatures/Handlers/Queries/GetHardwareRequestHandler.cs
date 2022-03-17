﻿using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.Features.CommonFeatures.Handlers.Queries;
using ITHelper.Domain.AssetInventoryEntities;


namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Handlers.Queries
{
    public class GetHardwareRequestHandler : GenericGetByIdRequestHandler<IHardwareRepository, HardwareDto, Hardware>
    {
        public GetHardwareRequestHandler(IHardwareRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
