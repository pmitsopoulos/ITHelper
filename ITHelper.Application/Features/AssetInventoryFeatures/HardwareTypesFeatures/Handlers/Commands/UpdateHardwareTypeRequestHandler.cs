using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareTypeDTOs.Validators;
using ITHelper.Application.Exceptions;
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
    public class UpdateHardwareTypeRequestHandler
        : IRequestHandler<UpdateHardwareTypeRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateHardwareTypeRequestHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateHardwareTypeRequest request, CancellationToken cancellationToken)
        {
           var response = new BaseResponse();

            if (!(await unitOfWork.DepartmentRepository.Exists(request.HardwareTypeDto.Id)))
            {
                response.Message = "The Hardware Type was not found and cannot be updated";
                response.Errors.Add(new NotFoundException(nameof(HardwareType), request.HardwareTypeDto.Id).Message);
                response.Success = false;
            }

            else
            {
                var validator = new UpdateHardwareTypeDtoValidator(unitOfWork.HardwareTypeRepository);

                var validationResult = await validator.ValidateAsync(request.HardwareTypeDto);

                if (!validationResult.IsValid)
                {
                    response.Message = "The Hardware Type is not valid";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }

                else
                {
                    var hardwareTypeTBU = await unitOfWork.HardwareTypeRepository.GetByIdAsync
                        (request.HardwareTypeDto.Id);

                    mapper.Map(request.HardwareTypeDto, hardwareTypeTBU);

                    await unitOfWork.HardwareTypeRepository.UpdateAsync(hardwareTypeTBU);
                    await unitOfWork.Save();

                    response.Success = true;
                    response.Message = "Hardware Type was updated successfully";
                    response.Id = hardwareTypeTBU.Id;
                }

            }
            return response;
        }
    }
}
