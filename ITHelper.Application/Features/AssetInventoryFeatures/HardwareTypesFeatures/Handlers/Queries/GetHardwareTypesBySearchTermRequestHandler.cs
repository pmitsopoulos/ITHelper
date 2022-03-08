using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Requests.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Handlers.Queries
{
    public class GetHardwareTypesBySearchTermRequestHandler
        : IRequestHandler<GetHardwareTypesBySearchTermRequest, List<HardwareTypeDto>>
    {
        private readonly IHardwareTypeRepository hardwareTypeRepository;
        private readonly IMapper mapper;

        public GetHardwareTypesBySearchTermRequestHandler(IHardwareTypeRepository hardwareTypeRepository,
            IMapper mapper )
        {
            this.hardwareTypeRepository = hardwareTypeRepository;
            this.mapper = mapper;
        }
        public async Task<List<HardwareTypeDto>> Handle(GetHardwareTypesBySearchTermRequest request, CancellationToken cancellationToken)
        {
            var hardwareTypes = await hardwareTypeRepository.GetBySearchTermAsync(request.SearchTerm);

            if(hardwareTypes == null)
            {
                throw new NotFoundException(nameof(HardwareType), request.SearchTerm);
            }

            return mapper.Map<List<HardwareTypeDto>>(hardwareTypes);
        }
    }
}
