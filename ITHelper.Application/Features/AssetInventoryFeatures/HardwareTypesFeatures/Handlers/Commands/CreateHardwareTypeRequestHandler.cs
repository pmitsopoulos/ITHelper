using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs.Validators;
using ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.HardwareTypesFeatures.Handlers.Commands
{
    public class CreateHardwareTypeRequestHandler : IRequestHandler<CreateHardwareTypeRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateHardwareTypeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateHardwareTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validator = new CreateHardwareTypeDtoValidator(unitOfWork.HardwareTypeRepository);

            var validationResult = await validator.ValidateAsync(request.HardwareTypeDto);

            if(!validationResult.IsValid)
            {
                response.Message = "The Hardware type is not valid";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                response.Success = true;
            }
            else
            {
                var hardwareTypeTBC = mapper.Map<HardwareType>(request.HardwareTypeDto);
                
                await unitOfWork.HardwareTypeRepository.CreateAsync(hardwareTypeTBC);
                await unitOfWork.Save();

                response.Message = "Hardware Type was created successfully.";
                response.Success = true;
            }
            return response;
            
        }
    }
}
