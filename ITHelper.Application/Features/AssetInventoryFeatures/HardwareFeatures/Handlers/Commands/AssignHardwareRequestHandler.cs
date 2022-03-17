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
    public class AssignHardwareRequestHandler : IRequestHandler<AssignHardwareRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AssignHardwareRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(AssignHardwareRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var hardwareExists = await unitOfWork.HardwareRepository.Exists(request.HardwareDto.Id);

            if(hardwareExists != true)
            {
                response.Message = $"The specified {typeof(Hardware).Name} does not exist";
                response.Success = false;
            }
            else
            {
                var validator = new AssignHardwareDtoValidator(unitOfWork.HardwareRepository);

                var validationResult = await validator.ValidateAsync(request.HardwareDto);

                if (validationResult.IsValid != true)
                {
                    response.Message = $"{typeof(Hardware).Name} is invalid";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }
                else
                {
                    var hardwareTBU = await unitOfWork.HardwareRepository.GetByIdAsync(request.HardwareDto.Id);

                    mapper.Map(request.HardwareDto, hardwareTBU);

                    await unitOfWork.HardwareRepository.UpdateAsync(hardwareTBU);
                    await unitOfWork.Save();

                    response.Message = $"{typeof(Hardware).Name} was assigned successfully.";
                    response.Success = true;
                    response.Id = hardwareTBU.Id;
                }
            }
            return response;
        
        }
    }
}
