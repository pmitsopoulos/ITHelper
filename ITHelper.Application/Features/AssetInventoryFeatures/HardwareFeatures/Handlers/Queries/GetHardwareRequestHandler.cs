using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Requests.Queries;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Handlers.Queries
{
    public class GetHardwareRequestHandler : IRequestHandler<GetHardwareRequest, HardwareDto>
    {
        private readonly IHardwareRepository hardwareRepository;
        private readonly IMapper mapper;

        public GetHardwareRequestHandler(IHardwareRepository hardwareRepository, IMapper mapper)
        {
            this.hardwareRepository = hardwareRepository;
            this.mapper = mapper;
        }
        public async Task<HardwareDto> Handle(GetHardwareRequest request, CancellationToken cancellationToken)
        {
            var hardware = await hardwareRepository.GetByIdAsync(request.Id);

            if(hardware == null)
            {
                throw new NotFoundException(nameof(Hardware), request.Id);
            }
            return mapper.Map<HardwareDto>(hardware);
        }
    }
}
