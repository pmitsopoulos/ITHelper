
using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.VendorsFeatures.Handlers.Commands
{
    public class DeleteVendorRequestHandler : IRequestHandler<DeleteVendorRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteVendorRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteVendorRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!(await unitOfWork.VendorRepository.Exists(request.Id)))
            {
                response.Message = "Vendor does not exist";
                response.Errors.Add(new NotFoundException(nameof(Vendor), request.Id).Message);
                response.Success = false;
            }
            else
            {
                await unitOfWork.VendorRepository.DeleteAsync(request.Id);
                await unitOfWork.Save();

                response.Message = "Vendor Deleted successfully";
                response.Success = true;
            }
            return response;
        }
    }
}
