using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.HardwareDTOs.Validators;
using ITHelper.Application.Exceptions;
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
    public class UpdateHardwareRequestHandler : IRequestHandler<UpdateHardwareRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateHardwareRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateHardwareRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if(!(await unitOfWork.HardwareRepository.Exists(request.HardwareDto.Id)))
            {
                response.Message = "The Hardware was not found and cannot be updated";
                response.Errors.Add(new NotFoundException(nameof(Hardware), request.HardwareDto.Id).Message);
                response.Success = false;
            }
            else
            {
                var validator = new UpdateHardwareDtoValidator(unitOfWork.HardwareRepository);

                var validationResult = await validator.ValidateAsync(request.HardwareDto);

                if(!validationResult.IsValid)
                {
                    response.Message = "The Hardware is not valid";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }
                else
                {
                    var hardwareTBU = await unitOfWork.HardwareRepository.GetByIdAsync(request.HardwareDto.Id);

                    mapper.Map(request.HardwareDto, hardwareTBU);

                    response.Success = true;
                    response.Message = "Hardware was updated successfully";
                    response.Id = hardwareTBU.Id;
                }
            }
            return response;
        }
    }
}
