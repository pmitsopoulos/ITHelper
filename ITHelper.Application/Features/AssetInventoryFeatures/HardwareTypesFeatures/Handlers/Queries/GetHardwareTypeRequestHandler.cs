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
    public class GetHardwareTypeRequestHandler : IRequestHandler<GetHardwareTypeRequest, HardwareTypeDto>
    {
        private readonly IHardwareTypeRepository hardwareTypeRepository;
        private readonly IMapper mapper;

        public GetHardwareTypeRequestHandler(IHardwareTypeRepository hardwareTypeRepository , IMapper mapper)
        {
            this.hardwareTypeRepository = hardwareTypeRepository;
            this.mapper = mapper;
        }
        public async Task<HardwareTypeDto> Handle(GetHardwareTypeRequest request, CancellationToken cancellationToken)
        {
            var hardwareType = await hardwareTypeRepository.GetByIdAsync(request.Id);
            if (hardwareType == null)
            {
                throw new NotFoundException(nameof(HardwareType), request.Id);
            }
            return mapper.Map<HardwareTypeDto>(hardwareType);   
        }
    }
}
