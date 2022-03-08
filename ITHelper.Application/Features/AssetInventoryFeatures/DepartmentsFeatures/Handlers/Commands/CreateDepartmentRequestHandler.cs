using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs.Validators;
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
    public class CreateDepartmentRequestHandler : IRequestHandler<CreateDepartmentRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateDepartmentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var validator = new CreateDepartmentDtoValidator(unitOfWork.DepartmentRepository);

            var validationResult = await validator.ValidateAsync(request.DepartmentDto);

            if(!validationResult.IsValid)
            {
                response.Message = "Department creation request failed.";
                response.Errors = validationResult.Errors.Select(x=>x.ErrorMessage).ToList();
                response.Success = false;
            }
            else
            {
                var departmentTBC = mapper.Map<Department>(request.DepartmentDto);

                await unitOfWork.DepartmentRepository.CreateAsync(departmentTBC);
                await unitOfWork.Save();

                response.Message = "Department was created successfully.";
                response.Success = true;
            }
            return response;
        }
    }
}
