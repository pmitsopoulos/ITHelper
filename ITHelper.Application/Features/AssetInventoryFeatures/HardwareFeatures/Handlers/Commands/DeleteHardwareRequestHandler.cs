using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
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
    public class DeleteHardwareRequestHandler : IRequestHandler<DeleteHardwareRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteHardwareRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteHardwareRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if(!(await unitOfWork.HardwareRepository.Exists(request.Id)))
            {
                response.Message = "Hardware does not exist";
                response.Errors.Add(new NotFoundException(nameof(Hardware), request.Id).Message);
                response.Success = false;
            }
            else
            {
                await unitOfWork.HardwareRepository.DeleteAsync(request.Id);
                await unitOfWork.Save();

                response.Message = "Hardware Deleted successfully";
                response.Success = true;
            }
            return response;
        }
    }
}
