using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs.Validators;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.DepartmentsFeatures.Handlers.Commands
{
    public class UpdateDepartmentRequestHandler : IRequestHandler<UpdateDepartmentRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateDepartmentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            
            if(!(await unitOfWork.DepartmentRepository.Exists(request.DepartmentDto.Id)))
            {
                response.Message = "The Department was not found and cannot be updated";
                response.Errors.Add(new NotFoundException(nameof(Department), request.DepartmentDto.Id).Message);
                response.Success = false;
            }
            else
            {
                var validator = new UpdateDepartmentDtoValidator(unitOfWork.DepartmentRepository);

                var validationResult = await validator.ValidateAsync(request.DepartmentDto);

                if(!validationResult.IsValid)
                {
                    response.Message = "The Department is not valid";
                    response.Errors = validationResult.Errors.Select(x=>x.ErrorMessage).ToList();
                    response.Success = false;
                }
                else
                {
                    var departmentTBU = await unitOfWork.DepartmentRepository.GetByIdAsync(request.DepartmentDto.Id);

                    mapper.Map(request.DepartmentDto, departmentTBU);

                    await unitOfWork.DepartmentRepository.UpdateAsync(departmentTBU);
                    await unitOfWork.Save();

                    response.Success = true;
                    response.Message = "Department was updated successfully";
                    response.Id = departmentTBU.Id;
                }
            }
            return response;
        }
    }
}
