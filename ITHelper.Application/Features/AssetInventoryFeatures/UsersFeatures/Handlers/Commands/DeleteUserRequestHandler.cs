using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.Exceptions;
using ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Requests.Commands;
using ITHelper.Application.Responses;
using ITHelper.Domain.AssetInventoryEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.AssetInventoryFeatures.UsersFeatures.Handlers.Commands
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            if (!(await unitOfWork.UserRepository.Exists(request.Id)))
            {
                response.Message = "User does not exist";
                response.Errors.Add(new NotFoundException(nameof(User), request.Id).Message);
                response.Success = false;
            }
            else
            {
                await unitOfWork.UserRepository.DeleteAsync(request.Id);
                await unitOfWork.Save();

                response.Message = "User Deleted Successfully";
                response.Success = true;
            }
            return response;
        }
    }
}
