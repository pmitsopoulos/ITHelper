using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
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
    public class DeleteDepartmentRequestHandler : IRequestHandler<DeleteDepartmentRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteDepartmentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if(!(await unitOfWork.DepartmentRepository.Exists(request.Id)))
            {
                response.Message = "Department does not exist";
                response.Errors.Add(new NotFoundException(nameof(Department), request.Id).Message);
                response.Success = false;
            }
            else
            {
                await unitOfWork.DepartmentRepository.DeleteAsync(request.Id);
                await unitOfWork.Save();

                response.Message = "Department Deleted successfully";
                response.Success = true;
            }
            return response;
        }
    }
}
