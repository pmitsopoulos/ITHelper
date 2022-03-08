using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs.Validators;
using ITHelper.Application.Features.AssetInventoryFeatures.HardwareFeatures.Requests.Commands;
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
    public class CreateHardwareRequestHandler : IRequestHandler<CreateHardwareRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateHardwareRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateHardwareRequest request, CancellationToken cancellationToken)
        {
            var response  = new BaseResponse(); 

            var validator = new CreateHardwareDtoValidator(unitOfWork.HardwareRepository);

            var validationResult = await validator.ValidateAsync(request.HardwareDto);

            if (!validationResult.IsValid)
            {
                response.Message = "Hardware creation request failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                response.Success = false;
            }
            else
            {
                var hardwareTBC = mapper.Map<Hardware>(request.HardwareDto);

                await unitOfWork.HardwareRepository.CreateAsync(hardwareTBC);
                await unitOfWork.Save();

                response.Message = "Hardware was created successfully.";
                response.Success = true;
            }

            return response;
        }
    }
}
