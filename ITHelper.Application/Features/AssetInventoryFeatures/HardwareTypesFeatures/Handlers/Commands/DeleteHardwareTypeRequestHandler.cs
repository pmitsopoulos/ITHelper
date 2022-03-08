using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
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
    public class DeleteHardwareTypeRequestHandler
        : IRequestHandler<DeleteHardwareTypeRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteHardwareTypeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteHardwareTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            
            if(!(await unitOfWork.HardwareTypeRepository.Exists(request.Id)))
            {
                response.Message = "Hardware Type does not exist";
                response.Errors.Add(new NotFoundException(nameof(HardwareType), request.Id).Message);
                response.Success = false;
            }
            else
            {
                await unitOfWork.HardwareTypeRepository.DeleteAsync(request.Id);
                await unitOfWork.Save();

                response.Success = true;
                response.Message = "Hardware Type deleted successfully";
            }
            return response;
        }
    }
}
