using AutoMapper;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs.Validators;
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
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, BaseResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateUserRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if(!(await unitOfWork.UserRepository.Exists(request.UserDto.Id)))
            {
                response.Message = "The Department was not found and cannot be updated";
                response.Errors.Add(new NotFoundException(nameof(User), request.UserDto.Id).Message);
                response.Success = false;
            }
            else
            {
                var validator = new UpdateUserDtoValidator(unitOfWork.UserRepository);

                var validationResult = await validator.ValidateAsync(request.UserDto);

                if(!validationResult.IsValid)
                {
                    response.Message = "The User is not valid";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    response.Success = false;
                }
                else
                {
                    var userTBU = await unitOfWork.UserRepository.GetByIdAsync(request.UserDto.Id);

                    mapper.Map(request.UserDto, userTBU);

                    response.Success = true;
                    response.Message = "User was updated successfully";
                    response.Id = userTBU.Id;
                }
            }
            return response;
        }
    }
}
